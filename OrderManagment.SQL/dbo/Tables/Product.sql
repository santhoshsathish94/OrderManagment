/*==============================================================*/
/* Table: Product                                               */
/*==============================================================*/
create table Product (
   Id                   int                  identity,
   ProductName          nvarchar(50)         not null,
   ProductDiscription   nvarchar(100)        null,
   UnitPrice            decimal(12,2)        null default 0,
   Quantity             int                  null default 0,
   constraint PK_PRODUCT primary key (Id)
)
GO
/*==============================================================*/
/* Index: IndexProductName                                      */
/*==============================================================*/
create index IndexProductName on Product (
ProductName ASC
)