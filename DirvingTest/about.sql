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

*易错题分组
select a.* from answers  as a 
left join questions as q on a.question_id=q.id 
where q.classification=3 and user_id=1
order by a.lastupdatetime limit 100;

select a.* from answers  as a 
left join questions as q on a.question_id=q.id 
where q.classification=3 and user_id=1 and a.errorNumber/a.answerNumber > 0.7
order by a.lastupdatetime limit 100;

select a.* from answers  as a 
left join questions as q on a.question_id=q.id 
where q.classification=3 and user_id=1 and a.errorNumber > 3
order by a.lastupdatetime limit 100;

select a.* from answers  as a 
left join questions as q on a.question_id=q.id 
where q.classification=3 and user_id=1 and a.errorNumber > 5
order by a.lastupdatetime limit 100;

select * from questions as q
left join answers as a on a.question_id=q.id and user_id=1
where a.question_id is NULL and q.classification=3 order by question_id limit 100;

最近错误的100个题(科目一)
select a.* from answers  as a 
left join questions as q on a.question_id=q.id 
where q.classification={1} and user_id={0}
order by a.lastupdatetime limit 100;

错误率大于70%的题100个题(科目一)
select a.* from answers  as a 
left join questions as q on a.question_id=q.id 
where q.classification={1} and user_id={0} and a.errorNumber/a.answerNumber > {2}
order by a.lastupdatetime limit 100;

错误超过3次的100个题(科目一）
select a.* from answers  as a 
left join questions as q on a.question_id=q.id 
where q.classification={1} and user_id={0} and a.errorNumber > {2}
order by a.lastupdatetime limit 100;

错误超过5次的100个题(科目一）
select * from questions as q
left join answers as a on a.question_id=q.id and user_id={0}
where a.question_id is NULL and q.classification={1} order by question_id limit 100;
