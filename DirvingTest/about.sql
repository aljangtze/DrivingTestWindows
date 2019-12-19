delete from old_groups_id_relationship;
insert into old_groups_id_relationship select * from (select id, rowid,  name,type from groups order by id, type) order by rowid;
select * from old_groups_id_relationship;

UPDATE groups as a SET id = (select rowid from old_groups_id_relationship as b where a.old_id=b.group_id and a.type=b.type limit 1)
where exists (select * from old_groups_id_relationship as c where a.old_id=c.group_id and a.type=c.type);

UPDATE group_questions as a Set group_id=(select id from groups as b where a.old_group_id=b.old_id and a.type=b.type limit 1)
where exists (select * from groups as c where a.old_group_id=c.old_id and a.type=c.type);

UPDATE groups as a SET count = (select count from (select group_id, type, count(1) as count from group_questions group by group_id, type) as b where a.id=b.group_id and a.type=b.type limit 1)
where exists (select * from (select group_id, type, count(1) as count from group_questions group by group_id, type) as c where a.id=c.group_id and a.type=c.type);

vacuum