select * from tieas_cd_pjh;
select * from tieas_cdg_pjh;

select * from menu_hwy;

update menu_hwy set menu_rank = 2 where menu_parent='root';

insert into menu_hwy values('�׷��ڵ� ����', '�λ��������', '�׷��ڵ� ����' , '0');
insert into menu_hwy values('����ο� ����', '��Ȳ �� ���', '����ο� ����' , '4');
update menu_hwy set menu_name='�����ڵ� ����', menu_key='�����ڵ� ����' where menu_name='�λ��ڵ� ����';
ALTER TABLE menu_hwy DROP COLUMN menu_level;
delete from menu_hwy where menu_key='��å�ڵ� ����';

desc tieas_cdg_hwy;
select * from tieas_cdg_hwy;
select * from menu_hwy where menu_parent='root';
select * from menu_hwy where menu_parent='�λ��������';
commit;

-- �����ڵ� ����
-- �μ��ڵ� ����
desc tieas_cd_hwy;
alter table tieas_cd_hwy drop column datasys3;
desc tieas_cdg_hwy;
select * from tieas_cdg_hwy; -- �ڵ� �׷� ���� -> REL
delete from tieas_cdg_hwy where cdg_use='N';
select * from tieas_cd_hwy; -- �ڵ� ���� REL -> ��Ӵ�, �ƹ���
select * from thrm_dept_hwy; -- dept �ڵ� ����
select * from thrm_dept_hwy;

commit;

select cd.* from tieas_cd_hwy cd, tieas_cdg_hwy cdg where cd.cd_grpcd = cdg.cdg_grpcd and cd.cd_grpcd='DUT';