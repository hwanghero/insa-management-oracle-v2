select * from tieas_cd_pjh;
select * from tieas_cdg_pjh;

select * from menu_hwy;

update menu_hwy set menu_rank = 2 where menu_parent='root';

insert into menu_hwy values('그룹코드 관리', '인사기초정보', '그룹코드 관리' , '0');
insert into menu_hwy values('퇴사인원 추이', '현황 및 통계', '퇴사인원 추이' , '4');
update menu_hwy set menu_name='단위코드 관리', menu_key='단위코드 관리' where menu_name='인사코드 관리';
ALTER TABLE menu_hwy DROP COLUMN menu_level;
delete from menu_hwy where menu_key='직책코드 관리';

desc tieas_cdg_hwy;
select * from tieas_cdg_hwy;
select * from menu_hwy where menu_parent='root';
select * from menu_hwy where menu_parent='인사기초정보';
commit;

-- 단위코드 관리
-- 부서코드 관리
desc tieas_cd_hwy;
alter table tieas_cd_hwy drop column datasys3;
desc tieas_cdg_hwy;
select * from tieas_cdg_hwy; -- 코드 그룹 생성 -> REL
delete from tieas_cdg_hwy where cdg_use='N';
select * from tieas_cd_hwy; -- 코드 생성 REL -> 어머니, 아버지
select * from thrm_dept_hwy; -- dept 코드 생성
select * from thrm_dept_hwy;

commit;

select cd.* from tieas_cd_hwy cd, tieas_cdg_hwy cdg where cd.cd_grpcd = cdg.cdg_grpcd and cd.cd_grpcd='DUT';