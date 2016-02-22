/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2016/1/18 14:00:30                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('choose_course') and o.name = 'FK_CHOOSE_C_CHOOSE_CO_STUDENT')
alter table choose_course
   drop constraint FK_CHOOSE_C_CHOOSE_CO_STUDENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('choose_course') and o.name = 'FK_CHOOSE_C_CHOOSE_CO_COURSE')
alter table choose_course
   drop constraint FK_CHOOSE_C_CHOOSE_CO_COURSE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('classes') and o.name = 'FK_CLASSES_RELATIONS_MAJOR')
alter table classes
   drop constraint FK_CLASSES_RELATIONS_MAJOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('classes') and o.name = 'FK_CLASSES_RELATIONS_GRADE')
alter table classes
   drop constraint FK_CLASSES_RELATIONS_GRADE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('course') and o.name = 'FK_COURSE_RELATIONS_COURSE_T')
alter table course
   drop constraint FK_COURSE_RELATIONS_COURSE_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('course') and o.name = 'FK_COURSE_RELATIONS_CLASSROO')
alter table course
   drop constraint FK_COURSE_RELATIONS_CLASSROO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('course') and o.name = 'FK_COURSE_RELATIONS_MAJOR')
alter table course
   drop constraint FK_COURSE_RELATIONS_MAJOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('student') and o.name = 'FK_STUDENT_RELATIONS_MAJOR')
alter table student
   drop constraint FK_STUDENT_RELATIONS_MAJOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('student') and o.name = 'FK_STUDENT_RELATIONS_GRADE')
alter table student
   drop constraint FK_STUDENT_RELATIONS_GRADE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('student') and o.name = 'FK_STUDENT_RELATIONS_CLASSES')
alter table student
   drop constraint FK_STUDENT_RELATIONS_CLASSES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('teacher') and o.name = 'FK_TEACHER_RELATIONS_MAJOR')
alter table teacher
   drop constraint FK_TEACHER_RELATIONS_MAJOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('teacher') and o.name = 'FK_TEACHER_RELATIONS_TEACHER_')
alter table teacher
   drop constraint FK_TEACHER_RELATIONS_TEACHER_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('teacher_course') and o.name = 'FK_TEACHER__TEACHER_C_TEACHER')
alter table teacher_course
   drop constraint FK_TEACHER__TEACHER_C_TEACHER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('teacher_course') and o.name = 'FK_TEACHER__TEACHER_C_COURSE')
alter table teacher_course
   drop constraint FK_TEACHER__TEACHER_C_COURSE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('admin')
            and   type = 'U')
   drop table admin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('announcement')
            and   type = 'U')
   drop table announcement
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('choose_course')
            and   name  = 'choose_course2_FK'
            and   indid > 0
            and   indid < 255)
   drop index choose_course.choose_course2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('choose_course')
            and   name  = 'choose_course_FK'
            and   indid > 0
            and   indid < 255)
   drop index choose_course.choose_course_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('choose_course')
            and   type = 'U')
   drop table choose_course
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('classes')
            and   name  = 'Relationship_12_FK'
            and   indid > 0
            and   indid < 255)
   drop index classes.Relationship_12_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('classes')
            and   name  = 'Relationship_9_FK'
            and   indid > 0
            and   indid < 255)
   drop index classes.Relationship_9_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('classes')
            and   type = 'U')
   drop table classes
go

if exists (select 1
            from  sysobjects
           where  id = object_id('classroom')
            and   type = 'U')
   drop table classroom
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('course')
            and   name  = 'Relationship_11_FK'
            and   indid > 0
            and   indid < 255)
   drop index course.Relationship_11_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('course')
            and   name  = 'Relationship_10_FK'
            and   indid > 0
            and   indid < 255)
   drop index course.Relationship_10_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('course')
            and   name  = 'Relationship_8_FK'
            and   indid > 0
            and   indid < 255)
   drop index course.Relationship_8_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('course')
            and   type = 'U')
   drop table course
go

if exists (select 1
            from  sysobjects
           where  id = object_id('course_type')
            and   type = 'U')
   drop table course_type
go

if exists (select 1
            from  sysobjects
           where  id = object_id('grade')
            and   type = 'U')
   drop table grade
go

if exists (select 1
            from  sysobjects
           where  id = object_id('major')
            and   type = 'U')
   drop table major
go

if exists (select 1
            from  sysobjects
           where  id = object_id('school_information')
            and   type = 'U')
   drop table school_information
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('student')
            and   name  = 'Relationship_5_FK'
            and   indid > 0
            and   indid < 255)
   drop index student.Relationship_5_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('student')
            and   name  = 'Relationship_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index student.Relationship_4_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('student')
            and   name  = 'Relationship_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index student.Relationship_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('student')
            and   type = 'U')
   drop table student
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('teacher')
            and   name  = 'Relationship_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index teacher.Relationship_3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('teacher')
            and   name  = 'Relationship_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index teacher.Relationship_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('teacher')
            and   type = 'U')
   drop table teacher
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('teacher_course')
            and   name  = 'teacher_course2_FK'
            and   indid > 0
            and   indid < 255)
   drop index teacher_course.teacher_course2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('teacher_course')
            and   name  = 'teacher_course_FK'
            and   indid > 0
            and   indid < 255)
   drop index teacher_course.teacher_course_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('teacher_course')
            and   type = 'U')
   drop table teacher_course
go

if exists (select 1
            from  sysobjects
           where  id = object_id('teacher_position')
            and   type = 'U')
   drop table teacher_position
go

/*==============================================================*/
/* Table: admin                                                 */
/*==============================================================*/
create table admin (
   admin_id             varchar(50)          not null,
   admin_password       varchar(50)          not null,
   constraint PK_ADMIN primary key nonclustered (admin_id)
)
go

/*==============================================================*/
/* Table: announcement                                          */
/*==============================================================*/
create table announcement (
   announcement_id      int                  not null,
   announcement_content text                 not null,
   announcement_title   varchar(1024)        not null,
   announcement_attachment varchar(1024)        null,
   constraint PK_ANNOUNCEMENT primary key nonclustered (announcement_id)
)
go

/*==============================================================*/
/* Table: choose_course                                         */
/*==============================================================*/
create table choose_course (
   student_id           varchar(50)          not null,
   course_id            varchar(50)          not null,
   constraint PK_CHOOSE_COURSE primary key (student_id, course_id)
)
go

/*==============================================================*/
/* Index: choose_course_FK                                      */
/*==============================================================*/
create index choose_course_FK on choose_course (
student_id ASC
)
go

/*==============================================================*/
/* Index: choose_course2_FK                                     */
/*==============================================================*/
create index choose_course2_FK on choose_course (
course_id ASC
)
go

/*==============================================================*/
/* Table: classes                                               */
/*==============================================================*/
create table classes (
   class_id             varchar(50)          not null,
   grade_id             varchar(50)          not null,
   major_id             varchar(50)          not null,
   class_name           varchar(50)          not null,
   constraint PK_CLASSES primary key nonclustered (class_id)
)
go

/*==============================================================*/
/* Index: Relationship_9_FK                                     */
/*==============================================================*/
create index Relationship_9_FK on classes (
grade_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_12_FK                                    */
/*==============================================================*/
create index Relationship_12_FK on classes (
major_id ASC
)
go

/*==============================================================*/
/* Table: classroom                                             */
/*==============================================================*/
create table classroom (
   classroom_id         varchar(50)          not null,
   classroom_name       varchar(50)          not null,
   constraint PK_CLASSROOM primary key nonclustered (classroom_id)
)
go

/*==============================================================*/
/* Table: course                                                */
/*==============================================================*/
create table course (
   course_id            varchar(50)          not null,
   classroom_id         varchar(50)          not null,
   course_type_id       varchar(50)          not null,
   major_id             varchar(50)          not null,
   course_name          varchar(50)          not null,
   course_time          varchar(50)          null,
   constraint PK_COURSE primary key nonclustered (course_id)
)
go

/*==============================================================*/
/* Index: Relationship_8_FK                                     */
/*==============================================================*/
create index Relationship_8_FK on course (
major_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_10_FK                                    */
/*==============================================================*/
create index Relationship_10_FK on course (
course_type_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_11_FK                                    */
/*==============================================================*/
create index Relationship_11_FK on course (
classroom_id ASC
)
go

/*==============================================================*/
/* Table: course_type                                           */
/*==============================================================*/
create table course_type (
   course_type_id       varchar(50)          not null,
   course_type_name     varchar(50)          not null,
   constraint PK_COURSE_TYPE primary key nonclustered (course_type_id)
)
go

/*==============================================================*/
/* Table: grade                                                 */
/*==============================================================*/
create table grade (
   grade_id             varchar(50)          not null,
   grade_name           varchar(50)          not null,
   constraint PK_GRADE primary key nonclustered (grade_id)
)
go

/*==============================================================*/
/* Table: major                                                 */
/*==============================================================*/
create table major (
   major_id             varchar(50)          not null,
   major_name           varchar(50)          not null,
   constraint PK_MAJOR primary key nonclustered (major_id)
)
go

/*==============================================================*/
/* Table: school_information                                    */
/*==============================================================*/
create table school_information (
   school_information_id varchar(50)          not null,
   school_information_name varchar(50)          not null,
   constraint PK_SCHOOL_INFORMATION primary key nonclustered (school_information_id)
)
go

/*==============================================================*/
/* Table: student                                               */
/*==============================================================*/
create table student (
   student_id           varchar(50)          not null,
   grade_id             varchar(50)          not null,
   class_id             varchar(50)          not null,
   major_id             varchar(50)          not null,
   student_name         varchar(50)          not null,
   student_sex          bit                  not null,
   student_tel          varchar(50)          not null,
   student_places       varchar(20)          not null,
   student_password     varchar(50)          not null,
   student_score        varchar(1024)        not null,
   constraint PK_STUDENT primary key nonclustered (student_id)
)
go

/*==============================================================*/
/* Index: Relationship_1_FK                                     */
/*==============================================================*/
create index Relationship_1_FK on student (
major_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_4_FK                                     */
/*==============================================================*/
create index Relationship_4_FK on student (
grade_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_5_FK                                     */
/*==============================================================*/
create index Relationship_5_FK on student (
class_id ASC
)
go

/*==============================================================*/
/* Table: teacher                                               */
/*==============================================================*/
create table teacher (
   teacher_id           varchar(50)          not null,
   teacher_position_id  varchar(50)          not null,
   major_id             varchar(50)          not null,
   teacher_name         varchar(50)          not null,
   teacher_sex          bit                  not null,
   teacher_tel          varchar(50)          not null,
   teacher_password     varchar(50)          not null,
   constraint PK_TEACHER primary key nonclustered (teacher_id)
)
go

/*==============================================================*/
/* Index: Relationship_2_FK                                     */
/*==============================================================*/
create index Relationship_2_FK on teacher (
major_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_3_FK                                     */
/*==============================================================*/
create index Relationship_3_FK on teacher (
teacher_position_id ASC
)
go

/*==============================================================*/
/* Table: teacher_course                                        */
/*==============================================================*/
create table teacher_course (
   teacher_id           varchar(50)          not null,
   course_id            varchar(50)          not null,
   constraint PK_TEACHER_COURSE primary key (teacher_id, course_id)
)
go

/*==============================================================*/
/* Index: teacher_course_FK                                     */
/*==============================================================*/
create index teacher_course_FK on teacher_course (
teacher_id ASC
)
go

/*==============================================================*/
/* Index: teacher_course2_FK                                    */
/*==============================================================*/
create index teacher_course2_FK on teacher_course (
course_id ASC
)
go

/*==============================================================*/
/* Table: teacher_position                                      */
/*==============================================================*/
create table teacher_position (
   teacher_position_id  varchar(50)          not null,
   teacher_position_name varchar(20)          not null,
   constraint PK_TEACHER_POSITION primary key nonclustered (teacher_position_id)
)
go

alter table choose_course
   add constraint FK_CHOOSE_C_CHOOSE_CO_STUDENT foreign key (student_id)
      references student (student_id)
go

alter table choose_course
   add constraint FK_CHOOSE_C_CHOOSE_CO_COURSE foreign key (course_id)
      references course (course_id)
go

alter table classes
   add constraint FK_CLASSES_RELATIONS_MAJOR foreign key (major_id)
      references major (major_id)
go

alter table classes
   add constraint FK_CLASSES_RELATIONS_GRADE foreign key (grade_id)
      references grade (grade_id)
go

alter table course
   add constraint FK_COURSE_RELATIONS_COURSE_T foreign key (course_type_id)
      references course_type (course_type_id)
go

alter table course
   add constraint FK_COURSE_RELATIONS_CLASSROO foreign key (classroom_id)
      references classroom (classroom_id)
go

alter table course
   add constraint FK_COURSE_RELATIONS_MAJOR foreign key (major_id)
      references major (major_id)
go

alter table student
   add constraint FK_STUDENT_RELATIONS_MAJOR foreign key (major_id)
      references major (major_id)
go

alter table student
   add constraint FK_STUDENT_RELATIONS_GRADE foreign key (grade_id)
      references grade (grade_id)
go

alter table student
   add constraint FK_STUDENT_RELATIONS_CLASSES foreign key (class_id)
      references classes (class_id)
go

alter table teacher
   add constraint FK_TEACHER_RELATIONS_MAJOR foreign key (major_id)
      references major (major_id)
go

alter table teacher
   add constraint FK_TEACHER_RELATIONS_TEACHER_ foreign key (teacher_position_id)
      references teacher_position (teacher_position_id)
go

alter table teacher_course
   add constraint FK_TEACHER__TEACHER_C_TEACHER foreign key (teacher_id)
      references teacher (teacher_id)
go

alter table teacher_course
   add constraint FK_TEACHER__TEACHER_C_COURSE foreign key (course_id)
      references course (course_id)
go

