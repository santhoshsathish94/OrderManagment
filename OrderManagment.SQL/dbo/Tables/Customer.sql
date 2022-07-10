/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table Customer (
   Id                   int                  identity,
   FirstName            nvarchar(40)         not null,
   LastName             nvarchar(40)         not null,
   Address				nvarchar(100)		 null,
   EmailAddress		    nvarchar(100)		 null,
   City                 nvarchar(40)         null,
   Country              nvarchar(40)         null,
   Phone                nvarchar(20)         null,
   constraint PK_CUSTOMER primary key (Id)
)
GO
/*==============================================================*/
/* Index: IndexCustomerName                                     */
/*==============================================================*/
create index IndexCustomerName on Customer (
LastName ASC,
FirstName ASC
)
GO
/*==============================================================*/
/* Index: IndexCustomerEmail                                      */
/*==============================================================*/
create index IndexEmail on Customer (
EmailAddress ASC
)
GO

/*==============================================================*/
/* Index: IndexPhone	                                        */
/*==============================================================*/
create index IndexPhone on Customer (
Phone ASC
)