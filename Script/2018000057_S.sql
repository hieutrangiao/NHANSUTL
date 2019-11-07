CREATE PROCEDURE [dbo].[ARInvoiceItemsInfo_GetInvoiceItemByInvoiceIDForReport]
 @InvoiceID int
AS
BEGIN
SET NOCOUNT ON
 SELECT
  iv.*,
  i.ARInvoiceNo,
  (SELECT ICMeasureUnitName FROM dbo.ICMeasureUnits WHERE ICMeasureUnitID = iv.FK_ICMeasureUnitID) AS ICMeasureUnitName
 FROM dbo.ARInvoiceItems iv
  INNER JOIN dbo.ARInvoices i ON i.ARInvoiceID = iv.FK_ARInvoiceID
 WHERE iv.AAStatus = 'Alive'
  AND i.AAStatus = 'Alive'
  AND iv.FK_ARInvoiceID = @InvoiceID
END

select * from ARSaleOrderPaymentTimes

select * from ICStocks

insert into ICStocks
values
(
	0
	, 'Dummy'
	, ''
	, null
	, ''
	, null
	, ''
	, N''
	, N''
	, ''
	, 1
)
Go

insert into ICStocks
values
(
	2
	, 'Alive'
	, ''
	, null
	, ''
	, null
	, 'K03-04'
	, N'Kho SR Nguyễn Oanh'
	, N'Kho SR Nguyễn Oanh'
	, 'Sale'
	, 1
)
Go

insert into ICStocks
values
(
	3
	, 'Alive'
	, ''
	, null
	, ''
	, null
	, 'K03-02'
	, N'Kho SR Song Hành'
	, N'Kho SR Song Hành'
	, 'Sale'
	, 1
)
Go