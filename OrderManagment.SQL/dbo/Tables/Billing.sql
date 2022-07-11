/*==============================================================*/
/* Table: Billing                                              */
/*==============================================================*/
create table Billing (
   Id                   int                  identity,
   BillingTypeId        int			         not null default 0,
   BillingAddress       nvarchar(100)        null,
   DeliveryAddress      nvarchar(100)        null,
   BillingDate          datetime	         null,
   BillingAmount        decimal(12,2)        null default 0,
   IsPaid               bit                  not null default 0,
   BillingNumber        nvarchar(30)         null,
   TranscantionId       nvarchar(30)         null,
   constraint PK_BILLING primary key (Id)
)
GO
/*==============================================================*/
/* Index: IndexBillingDate                                      */
/*==============================================================*/
create index IndexBillingDate on Billing (
BillingDate ASC
)
GO
/*==============================================================*/
/* Index: IndexBillingNumber                                    */
/*==============================================================*/
create index IndexBillingNumber on Billing (
BillingNumber ASC
)