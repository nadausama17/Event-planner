--------------------------------------------------------
--  File created - ÇáÃÑÈÚÇÁ-íæáíæ-01-2020   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence DEPARTMENTS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "DEPARTMENTS_SEQ"  MINVALUE 1 MAXVALUE 9990 INCREMENT BY 10 START WITH 280 NOCACHE  NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence EMPLOYEES_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "EMPLOYEES_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 207 NOCACHE  NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence LOCATIONS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "LOCATIONS_SEQ"  MINVALUE 1 MAXVALUE 9900 INCREMENT BY 100 START WITH 3300 NOCACHE  NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence SEC_ID
--------------------------------------------------------

   CREATE SEQUENCE  "SEC_ID"  MINVALUE 1 MAXVALUE 2000 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence SEQ_I
--------------------------------------------------------

   CREATE SEQUENCE  "SEQ_I"  MINVALUE 1 MAXVALUE 2000 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table ATTEND
--------------------------------------------------------

  CREATE TABLE "ATTEND" 
   (	"EVENT_NO" NUMBER(10,0), 
	"USER_EMAIL" VARCHAR2(1000 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table EVENT
--------------------------------------------------------

  CREATE TABLE "EVENT" 
   (	"EVENT_ID" NUMBER(*,0), 
	"NAMEE" VARCHAR2(1000 BYTE), 
	"DESCRIPTION" VARCHAR2(1000 BYTE), 
	"S_TIME" NUMBER(10,0), 
	"E_TIME" NUMBER(10,0), 
	"DATEE" DATE, 
	"USER_EMAIL" VARCHAR2(1000 BYTE), 
	"HALL_NO" NUMBER(10,0), 
	"E_STATUS" NUMBER(*,0), 
	"MAX_STUDENT" NUMBER(10,0), 
	"ACTUAL_ATTEND" NUMBER(30,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table HALL
--------------------------------------------------------

  CREATE TABLE "HALL" 
   (	"ID_HALL" NUMBER(*,0), 
	"HALL_NAME" VARCHAR2(1000 BYTE), 
	"NO_CHAIRS" NUMBER(*,0), 
	"USER_EMAIL" VARCHAR2(1000 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table USERR
--------------------------------------------------------

  CREATE TABLE "USERR" 
   (	"USER_EMAIL" VARCHAR2(1000 BYTE), 
	"F_NAME" VARCHAR2(1000 BYTE), 
	"L_NAME" VARCHAR2(1000 BYTE), 
	"TYPEE" NUMBER(10,0), 
	"PASSWORDS" VARCHAR2(255 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

---------------------------------------------------
--   DATA FOR TABLE HALL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into HALL
Insert into HALL (ID_HALL,HALL_NAME,NO_CHAIRS,USER_EMAIL) values (1,'hall1',50,'nada');
Insert into HALL (ID_HALL,HALL_NAME,NO_CHAIRS,USER_EMAIL) values (2,'hall2',60,'nada');

---------------------------------------------------
--   END DATA FOR TABLE HALL
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE USERR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into USERR
Insert into USERR (USER_EMAIL,F_NAME,L_NAME,TYPEE,PASSWORDS) values ('salma.bom','salma','bom',2,'aaa');
Insert into USERR (USER_EMAIL,F_NAME,L_NAME,TYPEE,PASSWORDS) values ('nada2','nadaaa','usama',3,'1');
Insert into USERR (USER_EMAIL,F_NAME,L_NAME,TYPEE,PASSWORDS) values ('nada','nada','usama',1,'1');

---------------------------------------------------
--   END DATA FOR TABLE USERR
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE EVENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EVENT
Insert into EVENT (EVENT_ID,NAMEE,DESCRIPTION,S_TIME,E_TIME,DATEE,USER_EMAIL,HALL_NO,E_STATUS,MAX_STUDENT,ACTUAL_ATTEND) values (1,'Sham El nsem','event',12,2,to_timestamp('20-MAY-20 06.47.06.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'salma.bom',null,2,50,0);
Insert into EVENT (EVENT_ID,NAMEE,DESCRIPTION,S_TIME,E_TIME,DATEE,USER_EMAIL,HALL_NO,E_STATUS,MAX_STUDENT,ACTUAL_ATTEND) values (6,'event6','ay 7aga',11,1,to_timestamp('20-MAY-20 12.37.24.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'salma.bom',null,2,50,0);
Insert into EVENT (EVENT_ID,NAMEE,DESCRIPTION,S_TIME,E_TIME,DATEE,USER_EMAIL,HALL_NO,E_STATUS,MAX_STUDENT,ACTUAL_ATTEND) values (3,'Ramdan Kareem','htgrf',4,8,to_timestamp('15-MAY-20 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'nada',1,1,300,2);
Insert into EVENT (EVENT_ID,NAMEE,DESCRIPTION,S_TIME,E_TIME,DATEE,USER_EMAIL,HALL_NO,E_STATUS,MAX_STUDENT,ACTUAL_ATTEND) values (2,'event2','e',12,2,to_timestamp('21-MAY-20 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'salma.bom',1,1,40,24);
Insert into EVENT (EVENT_ID,NAMEE,DESCRIPTION,S_TIME,E_TIME,DATEE,USER_EMAIL,HALL_NO,E_STATUS,MAX_STUDENT,ACTUAL_ATTEND) values (4,'event3','ay 7aga',10,12,to_timestamp('27-MAY-20 01.08.16.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'salma.bom',null,2,70,0);
Insert into EVENT (EVENT_ID,NAMEE,DESCRIPTION,S_TIME,E_TIME,DATEE,USER_EMAIL,HALL_NO,E_STATUS,MAX_STUDENT,ACTUAL_ATTEND) values (5,'event5','ay 7aga',11,1,to_timestamp('21-MAY-20 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'nada',2,1,80,41);

---------------------------------------------------
--   END DATA FOR TABLE EVENT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ATTEND
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTEND
Insert into ATTEND (EVENT_NO,USER_EMAIL) values (2,'nada2');
Insert into ATTEND (EVENT_NO,USER_EMAIL) values (3,'nada2');
Insert into ATTEND (EVENT_NO,USER_EMAIL) values (5,'nada2');

---------------------------------------------------
--   END DATA FOR TABLE ATTEND
---------------------------------------------------
--------------------------------------------------------
--  Constraints for Table ATTEND
--------------------------------------------------------

  ALTER TABLE "ATTEND" ADD PRIMARY KEY ("EVENT_NO", "USER_EMAIL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table EVENT
--------------------------------------------------------

  ALTER TABLE "EVENT" MODIFY ("EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" MODIFY ("NAMEE" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" MODIFY ("S_TIME" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" MODIFY ("E_TIME" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" MODIFY ("DATEE" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" MODIFY ("USER_EMAIL" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" ADD PRIMARY KEY ("EVENT_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "EVENT" MODIFY ("MAX_STUDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table HALL
--------------------------------------------------------

  ALTER TABLE "HALL" MODIFY ("ID_HALL" NOT NULL ENABLE);
 
  ALTER TABLE "HALL" MODIFY ("HALL_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "HALL" MODIFY ("NO_CHAIRS" NOT NULL ENABLE);
 
  ALTER TABLE "HALL" ADD PRIMARY KEY ("ID_HALL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table USERR
--------------------------------------------------------

  ALTER TABLE "USERR" MODIFY ("USER_EMAIL" NOT NULL ENABLE);
 
  ALTER TABLE "USERR" ADD PRIMARY KEY ("USER_EMAIL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "USERR" MODIFY ("F_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "USERR" MODIFY ("L_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "USERR" MODIFY ("TYPEE" NOT NULL ENABLE);
 
  ALTER TABLE "USERR" MODIFY ("PASSWORDS" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index SYS_C0015646
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C0015646" ON "ATTEND" ("EVENT_NO", "USER_EMAIL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0015635
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C0015635" ON "EVENT" ("EVENT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0015639
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C0015639" ON "HALL" ("ID_HALL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0015645
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C0015645" ON "USERR" ("USER_EMAIL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Ref Constraints for Table ATTEND
--------------------------------------------------------

  ALTER TABLE "ATTEND" ADD CONSTRAINT "FK1_ATTEND" FOREIGN KEY ("USER_EMAIL")
	  REFERENCES "USERR" ("USER_EMAIL") ENABLE;
 
  ALTER TABLE "ATTEND" ADD CONSTRAINT "FK2_ATTEND" FOREIGN KEY ("EVENT_NO")
	  REFERENCES "EVENT" ("EVENT_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EVENT
--------------------------------------------------------

  ALTER TABLE "EVENT" ADD CONSTRAINT "FK1_EVENT" FOREIGN KEY ("USER_EMAIL")
	  REFERENCES "USERR" ("USER_EMAIL") ENABLE;
 
  ALTER TABLE "EVENT" ADD CONSTRAINT "FK2_EVENT" FOREIGN KEY ("HALL_NO")
	  REFERENCES "HALL" ("ID_HALL") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table HALL
--------------------------------------------------------

  ALTER TABLE "HALL" ADD CONSTRAINT "FK1_HALL" FOREIGN KEY ("USER_EMAIL")
	  REFERENCES "USERR" ("USER_EMAIL") ENABLE;

--------------------------------------------------------
--  DDL for View EMP_DETAILS_VIEW
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "EMP_DETAILS_VIEW" ("EMPLOYEE_ID", "JOB_ID", "MANAGER_ID", "DEPARTMENT_ID", "LOCATION_ID", "COUNTRY_ID", "FIRST_NAME", "LAST_NAME", "SALARY", "COMMISSION_PCT", "DEPARTMENT_NAME", "JOB_TITLE", "CITY", "STATE_PROVINCE", "COUNTRY_NAME", "REGION_NAME") AS 
  SELECT
  e.employee_id,
  e.job_id,
  e.manager_id,
  e.department_id,
  d.location_id,
  l.country_id,
  e.first_name,
  e.last_name,
  e.salary,
  e.commission_pct,
  d.department_name,
  j.job_title,
  l.city,
  l.state_province,
  c.country_name,
  r.region_name
FROM
  employees e,
  departments d,
  jobs j,
  locations l,
  countries c,
  regions r
WHERE e.department_id = d.department_id
  AND d.location_id = l.location_id
  AND l.country_id = c.country_id
  AND c.region_id = r.region_id
  AND j.job_id = e.job_id
WITH READ ONLY;
--------------------------------------------------------
--  DDL for Procedure ACCEVENTSSTUD
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ACCEVENTSSTUD" 
(everow out sys_refcursor)
as
begin
open everow for
select EVENT_ID,NAMEE,DESCRIPTION,S_TIME,E_TIME
,DATEE,HALL_NAME
from event, hall
where E_STATUS=1 AND DATEE>= sysdate and event.HALL_NO=hall.ID_HALL;
end;

/

--------------------------------------------------------
--  DDL for Procedure DELETE_HALL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "DELETE_HALL" 
  (HID Number)
as
begin
	DELETE FROM hall WHERE id_hall= hid;
end;

/

--------------------------------------------------------
--  DDL for Procedure GETEVEATTENDANCE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GETEVEATTENDANCE" 
(eveID NUMBER,attendNO out number,maxstud out number)
as
begin
select  actual_attend,max_student
into attendno,maxstud
from event where event_id= eveid;
end;

/

--------------------------------------------------------
--  DDL for Procedure GETEVENTID
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GETEVENTID" 
(EID out number)
as
begin
select max(EVENT_ID)
into EID
from EVENT;
end;

/

--------------------------------------------------------
--  DDL for Procedure GETHALLID
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GETHALLID" 
(HID out number)
as
begin
select max(ID_HALL)
into hid
from HALL;
end;

/

--------------------------------------------------------
--  DDL for Procedure INSERT_HALL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "INSERT_HALL" 
(HID number, HName VARCHAR2,Aemail VARCHAR2,Nchairs Number)
as
begin
insert  into  HALL
(id_hall, hall_name, user_email, no_chairs)
Values (HID, HName, aemail, nchairs) ;
End ;

/

--------------------------------------------------------
--  DDL for Procedure UPDATE_HALL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "UPDATE_HALL" 
  (HID Number,HNAME VARCHAR2,Aemail VARCHAR2,NCHAIRS NUMBER)
as
begin
	update    hall 
	set   hall_name= hname,user_email= aemail, no_chairs= nchairs
	where   id_hall  =   HID  ;
end;

/

--------------------------------------------------------
--  DDL for Procedure VIEWHALLID
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "VIEWHALLID" 
(HID out sys_refcursor)
as
begin
open HID for
select ID_HALL
from HALL;
end;

/

