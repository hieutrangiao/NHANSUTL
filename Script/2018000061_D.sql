insert into ICStockLots
values
(
	1
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0001'
	, 1
	, ''
	, ''
	, ''
	, 3
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	2
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0002'
	, 2
	, ''
	, ''
	, ''
	, 3
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	3
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0003'
	, 3
	, ''
	, ''
	, ''
	, 3
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	4
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0004'
	, 4
	, ''
	, ''
	, ''
	, 3
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	5
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0005'
	, 5
	, ''
	, ''
	, ''
	, 3
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

select * from GELookupTables

insert into GELookupTables
values
(
	(select MAX(GELookupTableID)+1 from GELookupTables)
	, 'Alive'
	, 'ICStocks'
	, 'ICStocks'
	, 'ICStockName'
	, N'Tên kho'
)
Go

insert into GELookupTables
values
(
	(select MAX(GELookupTableID)+1 from GELookupTables)
	, 'Alive'
	, 'ICStockLots'
	, 'ICStockLots'
	, 'ICStockLotNo'
	, N'Mã lô'
)
Go

insert into ICStockLots
values
(
	0
	, 'Dummy'
	, GETDATE()
	, GETDATE()
	, ''
	, 0
	, ''
	, ''
	, ''
	, 0
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

select * from AAColumnAlias where AATableName = 'ICShipmentItems'


insert into ICStockLots
values
(
	7
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0007'
	, 1
	, ''
	, ''
	, ''
	, 7
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	8
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0008'
	, 2
	, ''
	, ''
	, ''
	, 7
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	6
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0006'
	, 1
	, ''
	, ''
	, ''
	, 7
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	9
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0009'
	, 4
	, ''
	, ''
	, ''
	, 7
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go

insert into ICStockLots
values
(
	10
	, 'Alive'
	, GETDATE()
	, GETDATE()
	, 'PL0010'
	, 5
	, ''
	, ''
	, ''
	, 5
	, 0
	, 0
	, ''
	, ''
	, 0
	, 0
	, 0
)
Go