replace into questions(
id,
url
,tittle
,image
,flash
,type
,moudle
,classification
,option1
,option2
,option3
,option4
,answer1
,answer2
,answer3
,answer4
,tittleEmphasize
,skillEmphasize
,notice
,option1Emphasize
,option2Emphasize
,option3Emphasize
,option4Emphasize)
VALUES
(
@id,
@url
,tittle
,@image
,@flash
,@type
,@moudle
,@classification
,@option1
,@option2
,@option3
,@option4
,@answer1
,@answer2
,@answer3
,@answer4
,@tittleEmphasize
,@skillEmphasize
,@notice
,@option1Emphasize
,@option2Emphasize
,@option3Emphasize
,@option4Emphasize);

)
from questions;


insert into groups (id, name, type, status, count, classification)
values
(@id, @name, @type, 1, @count, @classification)