// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Clients.SqlServer.Commands.Tree.Calculate;

/// <summary>
/// Построитель команды на вычисление дерева клиента.
/// </summary>
public class ClientTreeCalculateCommandBuilder : TreeCalculateCommandBuilder
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override string GetResultSql()
    {
        string aliasForLink = $"[{Prefix}k]";
        string aliasForLink1 = $"[{Prefix}k1]";
        string aliasForLink2 = $"[{Prefix}k2]";
        string aliasForResult = $"[{Prefix}r]";
        string aliasForTree = $"[{Prefix}t]";

        string cte = "[cte]";

        string linkTableFieldNameForId = $"[{LinkTableFieldNameForId}]";
        string linkTableFieldNameForParentId = $"[{LinkTableFieldNameForParentId}]";

        string linkTableName = $"[{LinkTableSchema}].[{LinkTableNameWithoutSchema}]";

        string treeTableFieldNameForId = $"[{TreeTableFieldNameForId}]";
        string treeTableFieldNameForParentId = $"[{TreeTableFieldNameForParentId}]";
        string treeTableFieldNameForTreeChildCount = $"[{TreeTableFieldNameForTreeChildCount}]";
        string treeTableFieldNameForTreeDescendantCount = $"[{TreeTableFieldNameForTreeDescendantCount}]";
        string treeTableFieldNameForTreeLevel = $"[{TreeTableFieldNameForTreeLevel}]";
        string treeTableFieldNameForTreePath = $"[{TreeTableFieldNameForTreePath}]";
        string treeTableFieldNameForTreePosition = $"[{TreeTableFieldNameForTreePosition}]";
        string treeTableFieldNameForTreeSort = $"[{TreeTableFieldNameForTreeSort}]";

        string treeTableName = $"[{TreeTableSchema}].[{TreeTableNameWithoutSchema}]";

        string val = "[val]";

        StringBuilder result = new($@"
while 1 = 1
begin;
	with {cte} as
	(
		select top 1
			{treeTableFieldNameForId},
			{treeTableFieldNameForParentId},
			{treeTableFieldNameForTreePosition}
		from
			{treeTableName}
		where
			{treeTableFieldNameForTreePosition} = 0
	)
	update {cte} set
		{treeTableFieldNameForTreePosition} = 
		(
			select
				MAX({aliasForTree}.{treeTableFieldNameForTreePosition}) + 10
			from
				{treeTableName} {aliasForTree}
			where
				COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0) = COALESCE({cte}.{treeTableFieldNameForParentId}, 0)
		)
	;

	if @@ROWCOUNT < 1 break;
end;

with {cte} as
(
	select
		{treeTableFieldNameForId},
		{treeTableFieldNameForTreeChildCount},
		{treeTableFieldNameForTreeDescendantCount},
		{treeTableFieldNameForTreeLevel},
		{treeTableFieldNameForTreePath},
		{treeTableFieldNameForTreeSort}
	from
		{treeTableName}
)
update {cte} set
	{treeTableFieldNameForTreeChildCount} = 
	(
		select
			COUNT_BIG(*)
		from
			{treeTableName} {aliasForTree}
		where
			{aliasForTree}.{treeTableFieldNameForParentId} = {cte}.{treeTableFieldNameForId}
	),
	{treeTableFieldNameForTreeDescendantCount} = 
	(
		select
			COUNT_BIG(*)
		from
			{linkTableName} {aliasForLink}
		where
			{aliasForLink}.{linkTableFieldNameForParentId} = {cte}.{treeTableFieldNameForId}
			and
			{aliasForLink}.{linkTableFieldNameForParentId} <> {aliasForLink}.{linkTableFieldNameForId}
	),
	{treeTableFieldNameForTreeLevel} = 
	(
		select
			COUNT_BIG(*) - 1
		from
			{linkTableName} {aliasForLink}
		where
			{aliasForLink}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
	),
	{treeTableFieldNameForTreePath} =
	(
		select
			COALESCE({aliasForResult}.{val}, N'')
		from
		(
			select
				{aliasForLink1}.{linkTableFieldNameForId},
				STUFF
				(
					(
						select
							',' + CONVERT(varchar(max), {aliasForLink2}.{linkTableFieldNameForParentId})
						from
							{linkTableName} {aliasForLink2}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} <> {aliasForLink2}.{linkTableFieldNameForId}
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) {val}
			from
				{linkTableName} {aliasForLink1}
			group by
				{aliasForLink1}.{linkTableFieldNameForId}
		) {aliasForResult}
		where
			{aliasForResult}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
	),
	{treeTableFieldNameForTreeSort} =
	(
		select
			COALESCE({aliasForResult}.{val}, N'')
		from
		(
			select
				{aliasForLink1}.{linkTableFieldNameForId},
				STUFF
				(
					(
						select
							',' + RIGHT('0000000000' + CONVERT(varchar(max), {aliasForTree}.{treeTableFieldNameForTreePosition}) + '.' + CONVERT(varchar(max), {aliasForLink2}.{linkTableFieldNameForParentId}), 10)
						from
							{linkTableName} {aliasForLink2}
							inner join {treeTableName} {aliasForTree}
								on {aliasForLink2}.{linkTableFieldNameForParentId} = {aliasForTree}.{treeTableFieldNameForId}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) {val}
			from
				{linkTableName} {aliasForLink1}
			group by
				{aliasForLink1}.{linkTableFieldNameForId}
		) {aliasForResult}
		where
			{aliasForResult}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
	)
");
        var parIds = Parameters.Ids;

        string? sqlForIdsSelectQuery = parIds.Any()
            ? string.Join(", ", parIds.Select(x => x.ParameterName))
            : SqlForIdsSelectQuery;

        if (!string.IsNullOrWhiteSpace(sqlForIdsSelectQuery))
        {
            result.Append($@"
where
	{cte}.{treeTableFieldNameForId} in
	(
		{sqlForIdsSelectQuery}
	)
;
");
        }

        return result.ToString();
    }

    #endregion Public methods
}
