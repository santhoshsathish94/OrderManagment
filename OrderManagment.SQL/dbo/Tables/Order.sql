﻿/*==============================================================*/
/* Table: "Order"                                               */
/*==============================================================*/
create table "Order" (
   Id                   int                  identity,
   OrderDate            datetime             not null default getdate(),
   OrderNumber          nvarchar(10)         null,
   CustomerId           int                  not null,
   TotalAmount          decimal(12,2)        null default 0,
   BillingId            int                  null
   constraint PK_ORDER primary key (Id)
)
GO
alter table "Order"
   add constraint FK_ORDER_REFERENCE_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
GO
alter table "Order"
   add constraint FK_ORDER_REFERENCE_BILLING foreign key (BillingId)
      references Billing (Id)
Go
/*==============================================================*/
/* Index: IndexOrderCustomerId                                  */
/*==============================================================*/
create index IndexOrderCustomerId on "Order" (
CustomerId ASC
)
GO
/*==============================================================*/
/* Index: IndexOrderOrderDate                                   */
/*==============================================================*/
create index IndexOrderOrderDate on "Order" (
OrderDate ASC
)
GO

/*==============================================================*/
/* Index: IndexOrderNumber                                      */
/*==============================================================*/
create index IndexOrderNumber on "Order" (
OrderNumber ASC
)
Go