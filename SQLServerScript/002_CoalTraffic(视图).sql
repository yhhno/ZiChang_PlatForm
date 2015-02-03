if exists (select 1
            from  sysobjects
           where  id = object_id('VSYS_Colliery')
            and   type = 'V')
   drop view VSYS_Colliery
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VSYS_CollieryNet')
            and   type = 'V')
   drop view VSYS_CollieryNet
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VSYS_Dictionary')
            and   type = 'V')
   drop view VSYS_Dictionary
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VSYS_OperateLog')
            and   type = 'V')
   drop view VSYS_OperateLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VSYS_Operator')
            and   type = 'V')
   drop view VSYS_Operator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VSys_Organization')
            and   type = 'V')
   drop view VSys_Organization
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VSys_Village')
            and   type = 'V')
   drop view VSys_Village
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_BadRecord')
            and   type = 'V')
   drop view VT_BadRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_BanlanceOfColliery')
            and   type = 'V')
   drop view VT_BanlanceOfColliery
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CarBadRecord')
            and   type = 'V')
   drop view VT_CarBadRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CarInfo')
            and   type = 'V')
   drop view VT_CarInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CarInfoOfOperator')
            and   type = 'V')
   drop view VT_CarInfoOfOperator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CarInfoOfRoomName')
            and   type = 'V')
   drop view VT_CarInfoOfRoomName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CheckBangInfo')
            and   type = 'V')
   drop view VT_CheckBangInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CheckBangInfoOfOperator')
            and   type = 'V')
   drop view VT_CheckBangInfoOfOperator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CoalKind')
            and   type = 'V')
   drop view VT_CoalKind
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CoalKindByColl')
            and   type = 'V')
   drop view VT_CoalKindByColl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CoalKindNameByOutLoadWeightOfFY')
            and   type = 'V')
   drop view VT_CoalKindNameByOutLoadWeightOfFY
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_ColieryAccount')
            and   type = 'V')
   drop view VT_ColieryAccount
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CollBalance')
            and   type = 'V')
   drop view VT_CollBalance
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CollRunCoalKind')
            and   type = 'V')
   drop view VT_CollRunCoalKind
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CollierySupervise')
            and   type = 'V')
   drop view VT_CollierySupervise
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CollierySuperviseInfo')
            and   type = 'V')
   drop view VT_CollierySuperviseInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CompareCollBalance')
            and   type = 'V')
   drop view VT_CompareCollBalance
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_CountTaxAssign')
            and   type = 'V')
   drop view VT_CountTaxAssign
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_EmptyWeight')
            and   type = 'V')
   drop view VT_EmptyWeight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_EmptyWeightOfOperator')
            and   type = 'V')
   drop view VT_EmptyWeightOfOperator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_GreenLightLoadWeight')
            and   type = 'V')
   drop view VT_GreenLightLoadWeight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_LoadWeight')
            and   type = 'V')
   drop view VT_LoadWeight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_LoadWeightByDay')
            and   type = 'V')
   drop view VT_LoadWeightByDay
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_LoadWeightEditLog')
            and   type = 'V')
   drop view VT_LoadWeightEditLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_LoadWeightOfOperator')
            and   type = 'V')
   drop view VT_LoadWeightOfOperator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('[VT_LoadWeightTax(PanXian)]')
            and   type = 'V')
   drop view [VT_LoadWeightTax(PanXian)]
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_MarkedCard')
            and   type = 'V')
   drop view VT_MarkedCard
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_MarkedCardCount')
            and   type = 'V')
   drop view VT_MarkedCardCount
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_MarkedCardSendLog')
            and   type = 'V')
   drop view VT_MarkedCardSendLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_MessagePerson')
            and   type = 'V')
   drop view VT_MessagePerson
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_Navicert')
            and   type = 'V')
   drop view VT_Navicert
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_NavicertLog')
            and   type = 'V')
   drop view VT_NavicertLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_NavicertPerson')
            and   type = 'V')
   drop view VT_NavicertPerson
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_OperateLog')
            and   type = 'V')
   drop view VT_OperateLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_OperateRoom')
            and   type = 'V')
   drop view VT_OperateRoom
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_OperatorOfCarInfo')
            and   type = 'V')
   drop view VT_OperatorOfCarInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_OutLoadWeight')
            and   type = 'V')
   drop view VT_OutLoadWeight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_OutLoadWeightCoalKind')
            and   type = 'V')
   drop view VT_OutLoadWeightCoalKind
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_OutLoadWeightOperator')
            and   type = 'V')
   drop view VT_OutLoadWeightOperator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_OutLoadWeightRealTime')
            and   type = 'V')
   drop view VT_OutLoadWeightRealTime
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_PitheadBillDetailIsUsed')
            and   type = 'V')
   drop view VT_PitheadBillDetailIsUsed
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_PitheadBillInfo')
            and   type = 'V')
   drop view VT_PitheadBillInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_Room')
            and   type = 'V')
   drop view VT_Room
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_RoomSupervise')
            and   type = 'V')
   drop view VT_RoomSupervise
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_RoomSuperviseInfo')
            and   type = 'V')
   drop view VT_RoomSuperviseInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_SuperviseInfo')
            and   type = 'V')
   drop view VT_SuperviseInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_TaxAssignDetail')
            and   type = 'V')
   drop view VT_TaxAssignDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_TaxItem')
            and   type = 'V')
   drop view VT_TaxItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_TempCard')
            and   type = 'V')
   drop view VT_TempCard
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_TransferAccounts')
            and   type = 'V')
   drop view VT_TransferAccounts
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_WaterBook')
            and   type = 'V')
   drop view VT_WaterBook
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_LoadWeightBackup')
            and   type = 'V')
   drop view VT_LoadWeightBackup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VT_MarkedCardSearch')
            and   type = 'V')
   drop view VT_MarkedCardSearch
go


create view VT_MarkedCardSearch
as
select MarkedCardCode,MarkedCardNo,CMK.CollCode,CollName,
CMK.CoalKindCode,CoalKindName,CMK.MarkedCardState,
BusinName as MarkedCardStateName
from TT_MarkedCard CMK
inner join Sys_Colliery C on C.CollCode = CMK.CollCode
inner join TT_CoalKind CK on CK.CoalKindCode = CMK.CoalKindCode
left join Sys_Dictionary D on D.BusinID = CMK.MarkedCardState
and BusinTypeID ='1004'
GO

Create view [dbo].[VT_LoadWeightBackup] as
SELECT lw.WeightCode, lw.TrafficCode, lw.NavicertCode, lw.MarkedCardCode,RemoteCardCode, lw.CollCode, 
lw.CoalKindCode, lw.CarOwnerName, lw.CarNo, lw.CarType,lw.LoadWeight, lw.EmptyWeight, 
case when (lw.LoadWeight-lw.EmptyWeight)>0 then lw.LoadWeight-lw.EmptyWeight else 0 end as NetWeight,
 lw.OverWeight, lw.TaxAmount,lw.FundAmount, lw.RoomCode, lw.BangType, lw.Operator, lw.WeightTime,   
lw.CustomerName,IsSealed, lw.TaxType, lw.IsFirstSite, lw.FrontImage, lw.BackImage, lw.UpImage, lw.RoomImage, lw.RandomCode, lw.TaxGroup, lw.CollName,  
room.RoomName,EmptyCode, room.Telephone AS RoomPhone, vill.BusinName AS VillageName, coll.VillageCode, lw.CoalKindName,coll.MineOwner,UpdateOperator,UpdateTime                    
FROM TT_LoadWeightBackup AS lw 
LEFT JOIN Sys_Colliery AS coll ON coll.CollCode = lw.CollCode 
LEFT  JOIN TT_Room AS room ON room.RoomCode = lw.RoomCode 
LEFT  JOIN 
(
SELECT BusinID, BusinName FROM Sys_Dictionary  
WHERE (BusinTypeID = '1002')
) AS vill ON coll.VillageCode = vill.BusinID
GO


create view VSYS_Colliery as
SELECT     coll.CollCode, coll.CollName, coll.OrgCode,org.OrgName, ISNULL(account.LowAccount, 0) AS LowAccount,Account, coll.VillageCode, coll.MineOwner, coll.MinePhone, 
                      coll.YearOutput, coll.CollState, coll.ImageLicence, coll.ImageRevenue, coll.ImageCompetency, coll.Remark, coll.IsForbid, 
                      sys1.BusinName AS VillageName, sys2.BusinName AS CollStateName, CASE coll.IsForbid WHEN 0 THEN '否' ELSE '是' END AS Forbid
FROM         dbo.Sys_Colliery AS coll LEFT  JOIN
                      dbo.Sys_Dictionary AS sys1 ON sys1.BusinID = coll.VillageCode AND sys1.BusinTypeID = '1002' LEFT OUTER JOIN
                      dbo.Sys_Dictionary AS sys2 ON sys2.BusinID = coll.CollState AND sys2.BusinTypeID = '1007' LEFT OUTER JOIN
                      dbo.TT_ColieryAccount AS account ON account.CollCode = coll.CollCode
left join Sys_Organization org on coll.OrgCode=org.orgCode
go

create view VSYS_CollieryNet as
SELECT     coll.CollCode, coll.CollName, coll.OrgCode, coll.VillageCode, coll.MineOwner, coll.MinePhone, coll.YearOutput, coll.CollState, coll.ImageLicence, 
                      coll.ImageRevenue, coll.ImageCompetency, coll.Remark, coll.IsForbid, sys1.BusinName AS VillageName, sys2.BusinName AS CollStateName, 
                      CASE coll.IsForbid WHEN 0 THEN '否' ELSE '是' END AS Forbid, sys3.BusinName AS CollProperty,ParcelCode,parcel.BusinName As ParcelName
FROM  dbo.Sys_Colliery AS coll 
LEFT  JOIN
(Select BusinID,BusinName from Sys_Dictionary where BusinTypeID='1002') sys1 ON sys1.BusinID = coll.VillageCode
LEFT  JOIN
(Select BusinID,BusinName from Sys_Dictionary where BusinTypeID='1007') sys2 ON sys2.BusinID = coll.CollState
LEFT JOIN
(Select BusinID,BusinName from Sys_Dictionary where BusinTypeID='1019') sys3 ON sys3.BusinID = coll.CollProperty
left join (Select BusinID,BusinName from Sys_Dictionary where BusinTypeID='1018') parcel on parcel.BusinID=coll.ParcelCode
GO

    
/*==============================================================*/    
/* View: VSYS_Dictionary                                        */    
/*==============================================================*/    
CREATE view dbo.VSYS_Dictionary as    
SELECT  BusinID, BusinName, a.BusinTypeID, CASE WHEN IsForbid = 1 THEN '禁用' ELSE '启用' END AS Status,    
     b.BusinTypeName AS TypeName,b.IsCanEdit,IsForBid    
FROM         dbo.Sys_Dictionary AS a    
left join Sys_BusinType b    
on a.BusinTypeID=b.BusinTypeID 
go

create view VSYS_OperateLog as
select logID,LOGTYPE,OperateTable,Operator,operatedate,operateIP,RELATIONID,Remark 
from SYS_OperateLog a
go

create view VSYS_Operator as
SELECT     a.UserCode, a.UserName, a.Password, a.IsForbid, a.OrgCode, a.Tel, a.Email, a.Address, a.ZipCode, a.PID, a.Gender, 
                      a.RegDate, a.MobileNo, b.OrgName, a.TypeCode, b.OrgType, c.RoomName
FROM         dbo.Sys_Operator AS a LEFT JOIN
                      dbo.Sys_Organization AS b ON a.OrgCode = b.OrgCode LEFT OUTER JOIN
                      dbo.TT_Room AS c ON a.TypeCode = c.RoomCode
go

create view VSys_Organization as
SELECT     dbo.Sys_Organization.OrgCode, dbo.Sys_Organization.OrgName, dbo.Sys_Organization.OrgLevel, dbo.Sys_Organization.ParentOrgCode, 
                      dbo.Sys_Organization.OrgSeq, dbo.Sys_Organization.OrgType, dbo.Sys_Organization.LinkMan, dbo.Sys_Organization.LinkManTel, 
                      dbo.Sys_Organization.Email, dbo.Sys_Organization.IsForbid, dbo.Sys_Organization.Remark, dbo.Sys_Organization.SysCode, 
                      dbo.Sys_Dictionary.BusinID AS OrgTypeId, dbo.Sys_Dictionary.BusinName AS OrgTypeName, dbo.Sys_Dictionary.BusinTypeID, 
                      dbo.Sys_Dictionary.DisplayOrder, dbo.Sys_Dictionary.IsForbid AS Expr1
FROM         dbo.Sys_Organization LEFT OUTER JOIN
                      dbo.Sys_Dictionary ON dbo.Sys_Organization.OrgType = dbo.Sys_Dictionary.BusinID
WHERE     (dbo.Sys_Dictionary.BusinTypeID = '1014') OR
                      (dbo.Sys_Organization.OrgType = '') OR
                      (dbo.Sys_Organization.OrgType IS NULL)
go

create view VSys_Village as
select BusinName,BusinID from Sys_Dictionary where BusinTypeID='1002' and  IsForbid='0'
go

create view VT_BadRecord as
SELECT     a.RecordID, a.NavicertCode, a.RoomCode, a.CarNo, a.Decript , a.BreakDate, a.AlarmType , 
                      a.AlarmStatus , a.CollCode , a.FrontImage, a.BackImage , a.UpImage , 
                      a.RoomImage , b.BusinName , c.CollName , r.RoomName 
FROM         dbo.TT_BadRecord AS a LEFT  JOIN
                          (SELECT     BusinID, BusinName
                            FROM          dbo.Sys_Dictionary
                            WHERE      (BusinTypeID = '1010')) AS b ON a.AlarmType = b.BusinID LEFT  JOIN
                      dbo.Sys_Colliery AS c ON a.CollCode = c.CollCode LEFT  JOIN
                      dbo.TT_Room AS r ON r.RoomCode = a.RoomCode
go

create view VT_BanlanceOfColliery as
select CA.CollCode,CollName,Account,MinePhone,
(Account - LowAccount) as Banlance
from TT_ColieryAccount CA
inner join Sys_Colliery C on C.CollCode = CA.CollCode
where (Account - LowAccount) <0.00 and MinePhone <>''
go

create view VT_CarBadRecord as
SELECT     dbo.TT_BadRecord.RecordID, dbo.TT_BadRecord.CarNo, dbo.TT_BadRecord.Decript, dbo.TT_BadRecord.BreakDate, dbo.TT_BadRecord.AlarmType, 
                      dbo.TT_BadRecord.AlarmStatus, dbo.TT_CarInfo.CarNo AS Expr1, dbo.TT_CarInfo.CarType, dbo.TT_CarInfo.CarOwnerName, 
                      dbo.TT_BadRecord.CollCode, dbo.TT_BadRecord.RoomCode, dbo.TT_Room.RoomName
FROM         dbo.TT_BadRecord LEFT OUTER JOIN
                      dbo.TT_CarInfo ON dbo.TT_BadRecord.CarNo = dbo.TT_CarInfo.CarNo INNER JOIN
                      dbo.TT_Room ON dbo.TT_BadRecord.RoomCode = dbo.TT_Room.RoomCode
go

create view VT_CarInfo as
SELECT     a.CarCode, a.RemoteCardCode, a.RoomCode, a.CarNo, a.CarType, a.EmptyWeight, a.MostWeight, a.Operator, a.BangType, a.DriveLicense, 
                      a.RandomCode, a.EmptyBangTime, a.CarOwnerName, a.CarOwnerIDCard, a.CarOwnerPhone, a.CarWidth, a.CarLength, a.CarHight, a.FirstImage, 
                      a.IsAuditing, a.AuditUser, a.AuditTime, a.Remark, r.RoomName, r.Principal, r.VillageCode, s.BusinName, a.DriverName, a.DriverIDCard, 
                      a.DriverPhone
FROM         dbo.TT_CarInfo AS a LEFT OUTER JOIN
                      dbo.TT_Room AS r ON a.RoomCode = r.RoomCode LEFT OUTER JOIN
                      dbo.Sys_Dictionary AS s ON s.BusinID = r.VillageCode AND s.BusinTypeID = '1002'
go

create view VT_CarInfoOfOperator as
select distinct RoomCode,Operator
from TT_CarInfo
go

create view VT_CarInfoOfRoomName as
select distinct CI.RoomCode,RoomName
from TT_CarInfo CI
inner join TT_Room R on R.RoomCode = CI.RoomCode
go

create view VT_CheckBangInfo as
SELECT CB.CheckCode, CB.WeightCode, LW.CollCode, LW.CollName, LW.CoalKindCode, LW.CoalKindName, CB.NavicertCode, 
CB.MarkedCardCode,LW.CarNo, LW.BangType, LW.NetWeight, CB.RoomCode, CB.IsPassed, R.RoomName, CB.CheckResult, 
CB.Operator, CB.CheckTime,cb.FrontImage,cb.BackImage,cb.UpImage,cb.RoomImage
FROM TT_CheckBang AS CB 
INNER JOIN TT_LoadWeight AS LW ON LW.WeightCode = CB.WeightCode 
INNER JOIN TT_Room AS R ON R.RoomCode = CB.RoomCode
go

create view VT_CheckBangInfoOfOperator as
select distinct Operator,Operator as Operatorsam,RoomCode
from VT_CheckBangInfo
go

create view VT_CoalKind as
Select a.*,b.BusinName TypeName ,
(case when a.IsForbid='1' then '禁用' else '启用' end) Forbid
from TT_CoalKind a 
left join 
(select BusinID,BusinName from Sys_Dictionary where BusinTypeID='1009') b
on a.TypeCode=b.BusinID
go

create view VT_CoalKindByColl as
SELECT     dbo.TT_CoalKind.CoalKindName, dbo.TT_CoalKind.CoalKindCode, dbo.Sys_Colliery.CollName, dbo.Sys_Colliery.CollCode
FROM         dbo.Sys_Colliery INNER JOIN
                      dbo.TT_CollRunCoalKind ON dbo.Sys_Colliery.CollCode = dbo.TT_CollRunCoalKind.CollCode INNER JOIN
                      dbo.TT_CoalKind ON dbo.TT_CollRunCoalKind.CoalKindCode = dbo.TT_CoalKind.CoalKindCode
go

create view VT_CoalKindNameByOutLoadWeightOfFY as
select distinct CoalKindName
from TT_OutLoadWeight
go

create view VT_ColieryAccount as
SELECT     b.CollCode, ISNULL(a.Account, 0) AS Account, a.EnabledCardNum, ISNULL(a.LowAccount, 0) AS LowAccount, a.MarkCardNum, ISNULL(a.Account, 0) 
                      - ISNULL(a.LowAccount, 0) AS IsLack, b.CollName, b.MineOwner, b.MinePhone, b.YearOutput, b.CollState, b.IsForbid,
                          (SELECT     BusinName
                            FROM          dbo.Sys_Dictionary
                            WHERE      (BusinTypeID = '1007') AND (BusinID = b.CollState)) AS CollStateName
FROM         dbo.Sys_Colliery AS b LEFT JOIN
                      dbo.TT_ColieryAccount AS a ON a.CollCode = b.CollCode
go

create view VT_CollBalance as
select a.CollName,a.CollCode,isnull(a.Account,0) Account,isnull(b.BalanceDate,'1900-1-1') BalanceDate,IsForbid from VT_ColieryAccount a
		left join
		(Select CollCode,max(BalanceDate) BalanceDate from TT_CollBalance group by CollCode) b
		on a.CollCode=b.CollCode
go

create view VT_CollRunCoalKind as
select a.*,CoalKindName,c.CollName from TT_CollRunCoalKind a
left join TT_CoalKind b on a.CoalKindCode=b.CoalKindCode
left join Sys_Colliery c on a.CollCode=c.CollCode
go

create view VT_CollierySupervise as
select CS.CollCode,CollName,count(*) as PersonCount,CS.IsForBid 
from TT_CollierySupervise CS
inner join Sys_Colliery C on C.CollCode = CS.CollCode
group by CS.CollCode,CollName,CS.IsForBid
go

create view VT_CollierySuperviseInfo as
select CollCode,CollName,  
case when (select PersonCount from VT_CollierySupervise a where IsForBid='0' and a.CollCode =CS.CollCode) is null then 0  
else (select PersonCount from VT_CollierySupervise b where IsForBid='0' and b.CollCode =CS.CollCode) end as PersonCount,  
case when (select PersonCount from VT_CollierySupervise c where IsForBid='0' and c.CollCode =CS.CollCode) is null then '1'  
 when (select PersonCount from VT_CollierySupervise d where IsForBid='0' and d.CollCode =CS.CollCode) = 0 then '1'   
else '0' end as ISForBid,  
case when (select PersonCount from VT_CollierySupervise e where IsForBid='0' and e.CollCode =CS.CollCode) is null then '是'  
when (select PersonCount from VT_CollierySupervise f where IsForBid='0' and f.CollCode =CS.CollCode) =  0 then '是'   
else '否' end as ForBid   
from  VT_CollierySupervise CS
go

create view VT_CompareCollBalance as
Select * from
(
Select VT_CollBalance.IsForbid,VT_CollBalance.CollCode,VT_CollBalance.CollName,cast(VT_CollBalance.Account as varchar)+'  ' Account ,cast(VT_CollBalance.Account+isnull(all1.TradeMoney,0)-isnull(all2.TaxAmount,0) as varchar)+'  ' as CollAmount,
(case((VT_CollBalance.Account+isnull(all1.TradeMoney,0)-isnull(all2.TaxAmount,0))-VT_CollBalance.Account) when 0.0000 then '否' else '是' end) as IsBalance,
cast((VT_CollBalance.Account+isnull(all1.TradeMoney,0)-isnull(all2.TaxAmount,0))-VT_CollBalance.Account as varchar)+' ' as Diff
from VT_CollBalance
left join 
(
	select CollCode,isnull(sum(TradeMoney),0) TradeMoney
	from
	(
		select Standard.CollCode,TradeMoney from VT_CollBalance as Standard
		left join 
		(select TradeDate,TradeMoney,CollCode from TT_WaterBook where TradeKind in('煤矿充值','账户平衡入账','账户平衡冲账')) as waterbook 
		on Standard.CollCode=waterbook.CollCode
		where waterbook.TradeDate>=Standard.BalanceDate
	) as Trade group by Trade.CollCode
) all1 on VT_CollBalance.CollCode=all1.CollCode
left join
(
	select CollCode,Sum(TaxAmount) TaxAmount from
	(
		select Standard0.CollCode,TaxAmount from VT_CollBalance as Standard0
		left join 
		(select CollCode,TaxAmount,WeightTime from TT_LoadWeight where IsSealed='0') as LoadWeight 
		on Standard0.CollCode=LoadWeight.CollCode
		where LoadWeight.WeightTime>=Standard0.BalanceDate
	) as weightAccount group by weightAccount.CollCode
) all2 on VT_CollBalance.CollCode=all2.CollCode
where VT_CollBalance.IsForbid='0'
) rel
go

create view VT_CountTaxAssign as
select TaxGroup,a.CoalKindCode,a.RoomCode,EffectTime,e.CoalKindName,a.TaxItemCode,c.ItemName,b.UnitCode,f.UnitName,c.ItemType,d.businName ItemTypeName,isnull(b.AssignAmount,0) AssignAmount 
from  TT_TaxItemDetail a
left join TT_TaxAssignDetail b on
a.ItemDetailId=b.ItemDetailId
left join TT_TaxItem c on a.TaxItemCode=c.TaxItemCode
left join (select BusinID,BusinName from dbo.Sys_Dictionary where BusinTypeID='1001') d
on d.BusinID=c.ItemType
left join TT_CoalKind e on a.CoalKindCode =e.CoalKindCode
left join dbo.TT_TaxUnit f on f.UnitCode=b.UnitCode
go

create view VT_EmptyWeight as
SELECT     a.*,
case a.IsLoadWeight when '1' then '是' else '否' end IsLoadWeightName,
r.RoomName,c.CarType   
FROM         dbo.TT_EmptyWeight AS a LEFT  JOIN    
                      dbo.TT_Room AS r ON a.RoomCode = r.RoomCode     
left join TT_CarInfo c on c.CarCode=a.CarCode
go

create view VT_EmptyWeightOfOperator as
select distinct Operator as OperatorCode,Operator,RoomCode
from VT_EmptyWeight
go

create view VT_GreenLightLoadWeight as
select isnull(WeightCode,'') WeightCode,isnull(CoalKindName,'') CoalKindName,isnull(CoalKindCode,'') CoalKindCode,
isnull(B.RoomName,'') RoomName,isnull(B.RoomCode,'') RoomCode
,isnull(a.CarNo,'') CarNo,isnull(a.CollName,'') CollName,isnull(A.CollCode,'') CollCode,
isnull(a.EmptyWeight,'0') EmptyWeight,
isnull(a.LoadWeight,'0') LoadWeight,isnull(NetWeight,'0') NetWeight,WeightTime,CarOwnerName,MineOwner,c.VillageCode from dbo.TT_LoadWeight A 
INNER JOIN TT_Room B on A.RoomCode=B.RoomCode 
INNER JOIN Sys_Colliery c on C.CollCode=a.CollCode
go

create view VT_LoadWeight as
SELECT lw.WeightCode, lw.TrafficCode, lw.NavicertCode, lw.MarkedCardCode,RemoteCardCode, lw.CollCode, 
lw.CoalKindCode, lw.CarOwnerName, lw.CarNo, lw.CarType,lw.LoadWeight, lw.EmptyWeight, 
case when (lw.LoadWeight-lw.EmptyWeight)>0 then lw.LoadWeight-lw.EmptyWeight else 0 end as NetWeight,
 lw.OverWeight, lw.TaxAmount,lw.FundAmount, lw.RoomCode, lw.BangType, lw.Operator, lw.WeightTime,   
lw.CustomerName,IsSealed, lw.TaxType, lw.IsFirstSite, lw.FrontImage, lw.BackImage, lw.UpImage, lw.RoomImage, lw.RandomCode, lw.TaxGroup, lw.CollName,  
room.RoomName,EmptyCode, room.Telephone AS RoomPhone, vill.BusinName AS VillageName, coll.VillageCode, lw.CoalKindName,coll.MineOwner                     
FROM TT_LoadWeight AS lw 
LEFT JOIN Sys_Colliery AS coll ON coll.CollCode = lw.CollCode 
LEFT  JOIN TT_Room AS room ON room.RoomCode = lw.RoomCode 
LEFT  JOIN 
(
SELECT BusinID, BusinName FROM Sys_Dictionary  
WHERE (BusinTypeID = '1002')
) AS vill ON coll.VillageCode = vill.BusinID
go

create view VT_LoadWeightByDay as
select a.RoomCode,a.CollCode,a.CoalKindCode,a.TaxGroup,a.NetWeight,a.TaxAmount,a.WeightTime,
b.CoalKindName,c.RoomName,d.CollName,e.businName as VillageName,d.VillageCode
from TT_LoadWeightByDay a
left join TT_COALKIND b on b.CoalKindCode=a.CoalKindCode
left join TT_ROOM c on c.RoomCode=a.RoomCode
left join sys_Colliery d on d.CollCode=a.CollCode
left join (select businID,businName from SYS_Dictionary where businTypeID='1002') e
on d.VillageCode=e.businID
go

create view VT_LoadWeightEditLog as
SELECT     a.LogID, a.WeightCode, a.BeforeNetWeight, a.BeforeCollCode, a.BeforeKindCode, a.BeforeNavicertCode, a.BeforeMarkedCardCode, a.AfterNetWeight, 
                      a.AfterCollCode, a.AfterKindCode, a.AfterNavicertCode, a.AfterMarkedCardCode, a.Remark, a.Operator, a.OperateDate, 
                      b.CollName AS BeforeCollieryName, c.CollName AS AfterCollieryName, d.CoalKindName AS BeforeKindName, e.CoalKindName AS AfterKindName, 
                      f.UserName AS OperatorName
FROM         dbo.TT_LoadWeightEditLog AS a LEFT OUTER JOIN
                      dbo.Sys_Colliery AS b ON b.CollCode = a.BeforeCollCode LEFT OUTER JOIN
                      dbo.Sys_Colliery AS c ON c.CollCode = a.AfterCollCode LEFT OUTER JOIN
                      dbo.TT_CoalKind AS d ON d.CoalKindCode = a.BeforeKindCode LEFT OUTER JOIN
                      dbo.TT_CoalKind AS e ON e.CoalKindCode = a.AfterKindCode LEFT OUTER JOIN
                      dbo.Sys_Operator AS f ON f.UserName = a.Operator
go

create view VT_LoadWeightOfOperator as
select distinct Operator,Operator as Operatorsam,RoomCode
from VT_LoadWeight
go

create view [VT_LoadWeightTax(PanXian)] as
select RoomName,WeightCode,MarkedCardCode,NavicertCode,CollName,CarNo,CoalKindName,CarOwnerName,CarType,BangType,
(cast(EmptyWeight as varchar))+' 吨' as EmptyWeight,(cast(LoadWeight as varchar)+' 吨') as 
LoadWeight,(cast(LoadWeight-EmptyWeight as varchar)+' 吨') as NetWeight, (cast(TaxAmount as varchar)+' 元') as TaxAmount,
(cast(FundAmount as varchar)+' 元') as FundAmount,WeightTime,Operator,RandomCode,
cast(
(
select isnull(sum(Amount),0) from TT_TaxItemDetail where TaxGroup= (select isnull(max(TaxGroup),0) 
from TT_TaxItemDetail 
where EffectTime<=a.WeightTime 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode ) 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode and 
TaxItemCode in ( select TaxItemCode from TT_TaxItem 
where ItemType in(select distinct businID from SYS_Dictionary where businName like '%价格调节基金%') ) 

) as varchar)+' 元' as JiaGeJiJin,
cast(
(
select isnull(sum(Amount),0) from TT_TaxItemDetail where TaxGroup= (select isnull(max(TaxGroup),0) 
from TT_TaxItemDetail 
where EffectTime<=a.WeightTime 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode ) 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode and 
TaxItemCode in ( select TaxItemCode from TT_TaxItem 
where ItemType in(select distinct businID from SYS_Dictionary where businName like '%安全生产风险抵押金%') ) 

) as varchar)+' 元' as shuitubaochi,
cast(
(
select isnull(sum(Amount),0) from TT_TaxItemDetail where TaxGroup= (select isnull(max(TaxGroup),0) 
from TT_TaxItemDetail 
where EffectTime<=a.WeightTime 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode ) 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode and 
TaxItemCode in ( select TaxItemCode from TT_TaxItem 
where ItemType in(select distinct businID from SYS_Dictionary where businName like '%国税%') ) 

) as varchar)+' 元' as guoshui,
cast((
select isnull(sum(Amount),0) from TT_TaxItemDetail where TaxGroup= (select isnull(max(TaxGroup),0) 
from TT_TaxItemDetail 
where EffectTime<=a.WeightTime 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode ) 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode and 
TaxItemCode in ( select TaxItemCode from TT_TaxItem 
where ItemType in(select distinct businID from SYS_Dictionary where businName like '%规费%') ) 

) as varchar)+' 元' as guifei,
cast((
select isnull(sum(Amount),0) from TT_TaxItemDetail where TaxGroup= (select isnull(max(TaxGroup),0) 
from TT_TaxItemDetail 
where EffectTime<=a.WeightTime 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode ) 
and RoomCode=a.RoomCode and CoalKindCode=a.CoalKindCode and 
TaxItemCode in ( select TaxItemCode from TT_TaxItem 
where ItemType in(select distinct businID from SYS_Dictionary where businName like '%地税%') ) 

) as varchar)+' 元' as dishui


from VT_LoadWeight a
go

create view VT_MarkedCard as
SELECT     a.MarkedCardNo, a.MarkedCardCode, a.CollCode, a.CoalKindCode,a.MarkedCardState, a.SendCardDate, a.Operator, 
                      a.DepartName,b.CollName, c.CoalKindName,
                      f.businName AS CardStateName, c.TypeCode, 
                      vill.businName AS VillageName, b.VillageCode
FROM         dbo.TT_MarkedCard AS a LEFT OUTER JOIN
                      dbo.sys_Colliery AS b ON a.CollCode = b.CollCode LEFT JOIN
                      dbo.TT_CoalKind AS c ON a.CoalKindCode = c.CoalKindCode LEFT  JOIN
                          (SELECT     businID, businName
                            FROM          dbo.SYS_Dictionary
                            WHERE      (businTypeID = '1004')) AS f ON a.MarkedCardState = f.businID LEFT  JOIN
                          (SELECT     businID, businName
                            FROM          dbo.SYS_Dictionary AS SYS_Dictionary_1
                            WHERE      (businTypeID = '1002')) AS vill ON b.VillageCode = vill.businID
go

create view VT_MarkedCardCount as
select CollCode,CoalKindCode,CollName,CoalKindName,count(MarkedCardState) StateCount  
,MarkedCardState   
from dbo.VT_MarkedCard  
group by CollCode,CoalKindCode,CollName,CoalKindName,MarkedCardState
go

create view VT_MarkedCardSendLog as
SELECT     tm.RecordID, tm.CollCode, tm.CoalKindCode, tm.SendCardDate, tm.Operator, s.CollName, tc.CoalKindName,vill.businName AS VillageName, s.VillageCode
FROM         dbo.TT_MarkedCardSendRecord AS tm LEFT OUTER JOIN
                      dbo.Sys_Colliery AS s ON s.CollCode = tm.CollCode LEFT OUTER JOIN
                      dbo.TT_CoalKind AS tc ON tc.CoalKindCode = tm.CoalKindCode
left join
(SELECT     businID, businName
                            FROM          dbo.SYS_Dictionary
                            WHERE      (businTypeID = '1002')) AS vill ON s.VillageCode = vill.businID
go

create view VT_MessagePerson as
select MCode,TypeCode,case TypeCode when '1' then '煤炭局'    
when '2' then '磅房' else '煤矿' end as TypeName,MPName,    
PhoneNumber,ReceiveTypeCode,case ReceiveTypeCode when 'ET' then '所有类型'   
when 'ES' then '实时' when 'ED' then '每日' when 'EW' then '每周' else '每月' end as ReceiveTypeName,IsForBid,    
case IsForBid when '0' then '否' else '是' end as ForBid    
from TT_MessagePerson
go

create view VT_Navicert as
SELECT     a.*,RoomName,b.businName as NavicertStateName    
FROM         dbo.TT_Navicert AS a left JOIN    
dbo.TT_Room ON a.RoomCode = dbo.TT_Room.RoomCode LEFT  JOIN    
  (SELECT     businID, businName    
    FROM          dbo.SYS_Dictionary    
    WHERE      (businTypeID = '1005')) AS b ON a.NavicertState = b.businID
go

create view VT_NavicertLog as
SELECT     a.LogID, a.NavicertCode, a.BeforeState, a.AfterState, a.Event, a.Remark, a.Operator AS OperateMan, a.OperateDate, c.BusinName AS BeforeStateName,
                       d.BusinName AS AfterStateName, b.CarNo, b.CarOwnerName, e.UserName AS OperateManNAME
FROM         dbo.TT_NavicertLog AS a LEFT OUTER JOIN
                      dbo.TT_Navicert AS b ON a.NavicertCode = b.NavicertCode LEFT OUTER JOIN
                          (SELECT     BusinID, BusinName
                            FROM          dbo.Sys_Dictionary
                            WHERE      (BusinTypeID = '1005')) AS c ON a.BeforeState = c.BusinID LEFT OUTER JOIN
                          (SELECT     BusinID, BusinName
                            FROM          dbo.Sys_Dictionary AS Sys_Dictionary_1
                            WHERE      (BusinTypeID = '1005')) AS d ON a.AfterState = d.BusinID LEFT OUTER JOIN
                      dbo.Sys_Operator AS e ON e.UserName = a.Operator
go

create view VT_NavicertPerson as
select distinct RoomCode,SendPerson as SPerson,SendPerson  
from TT_Navicert
go

create view VT_OperateLog as
SELECT     t.LogID, t.LogType, t.OperateTable, t.OperateIP, t.RelationID, t.Remark, t.OperateDate, s.UserName AS operatorName, s.UserCode  
FROM         dbo.Sys_OperateLog AS t LEFT OUTER JOIN  
                      dbo.Sys_Operator AS s ON s.UserName = t.Operator
go

create view VT_OperateRoom as
SELECT     dbo.TT_Room.RoomCode, dbo.TT_Room.RoomName, dbo.Sys_Operator.UserName, dbo.TT_Room.Principal, dbo.TT_Room.Telephone, 
                      dbo.TT_Room.RoomType, dbo.TT_Room.IsForbid, dbo.Sys_Operator.IsForbid AS Expr1, dbo.Sys_Operator.UserCode
FROM         dbo.TT_OperatorMonitorRoom INNER JOIN
                       dbo.Sys_Operator ON dbo.Sys_Operator.UserCode = dbo.TT_OperatorMonitorRoom.UserCode INNER JOIN
                      dbo.TT_Room ON dbo.TT_OperatorMonitorRoom.RoomCode = dbo.TT_Room.RoomCode
go

create view VT_OperatorOfCarInfo as
select distinct Operator as OperatorCode,Operator,roomCode
from TT_CarInfo
go

create view VT_OutLoadWeight as
select OutWeightCode,OTrafficCode,NavicertCode,CoalKindCode,CoalKindName,CarNo,  
CurrentWeight,ONetWeight,OverWeight,TaxAmount,FundAmount,TaxType,RandomCode,  
FrontImage,BackImage,UpImage,RoomImage,OLW.RoomCode,room.RoomName,Operator,WeightTime,  
case OutType when '2' then '出境' else '入境' end as OutType,BangType,DiveLicense,
CarDriverPhone,EmptyWeight,CarownerIDCard,CollName,IsNormal,SendUnits,ToUnits,
BillWeight,CarNoImage,OutWeightImage,Customers,CarOwnerName
from TT_OutLoadWeight OLW
left join TT_Room room on OLW.RoomCode=room.RoomCode
go

create view VT_OutLoadWeightCoalKind as
select distinct CoalKindName,RoomCode   
from VT_OutLoadWeight
go

create view VT_OutLoadWeightOperator as
select distinct Operator,Operator as OperatorSam,RoomCode 
from VT_OutLoadWeight
go

create view VT_OutLoadWeightRealTime as
select room.RoomCode,RoomName,out.WeightTime,out.OutWeightImage
from TT_Room room
left join 
(
	Select OutWeightCode,RoomCode,OutWeightImage,WeightTime
	from TT_OutLoadWeight
	where OutWeightCode in
	(
	Select max(OutWeightCode) OutWeightCode from TT_OutLoadWeight
	group by RoomCode
	)
) out on room.RoomCode=out.RoomCode
where room.RoomCode<>'0' and room.IsForbid='0'
go

create view VT_PitheadBillDetailIsUsed as
select distinct [Iedition],
case (
select count(*) from TT_PitheadBillDetail pb 
where pb.[Iedition]=TT_PitheadBillDetail.[Iedition] and [IsUsed] =0)
when 0 then '是' else '否' end as IsUsed,
(select min([PitheadCode]) 
	from TT_PitheadBillDetail PBD 
	where PBD.[Iedition] =TT_PitheadBillDetail.[Iedition] ) as MinPC,
(select max([PitheadCode]) 
	from TT_PitheadBillDetail PBD 
	where PBD.[Iedition] =TT_PitheadBillDetail.[Iedition] ) as MaxPC
from TT_PitheadBillDetail
go

create view VT_PitheadBillInfo as
select PBDate,Remark,[StartIedition],[EndIedition],
[StartNumber],[EndNumber],[Changnumber],[BalanceNum]
from TT_PitheadBill
go

create view VT_Room as
SELECT     a.RoomCode, a.VillageCode, a.RoomName, a.Principal, a.Telephone, a.TransportModel, a.RoomType, a.RoomIp, a.IsForbid, a.Remark, a.OnOff, 
                      DateDiff(minute,a.OffLineBegin, getdate()) as OffLineTime, a.CollCode, a.OffLineBegin, rt.BusinName AS RoomTypeName, (CASE OnOff WHEN '0' THEN '断开' WHEN '1' THEN '正常' END) 
                      AS OnOffName, (CASE a.IsForbid WHEN '1' THEN '禁用' WHEN '0' THEN '启用' END) AS Forbid, b.CollName, c.BusinName AS VillageName
FROM         dbo.TT_Room AS a LEFT OUTER JOIN
                      dbo.Sys_Colliery AS b ON a.CollCode = b.CollCode LEFT OUTER JOIN
                          (SELECT     BusinID, BusinName
                            FROM          dbo.Sys_Dictionary
                            WHERE      (BusinTypeID = '1002')) AS c ON a.VillageCode = c.BusinID LEFT OUTER JOIN
                          (SELECT     BusinID, BusinName
                            FROM          dbo.Sys_Dictionary AS Sys_Dictionary_1
                            WHERE      (BusinTypeID = '1003')) AS rt ON rt.BusinID = a.RoomType
go

create view VT_RoomSupervise as
select RS.RoomCode,RoomName,count(*) as PersonCount,RS.IsForBid   
from TT_RoomSupervise RS  
inner join TT_Room R on R.RoomCode = RS.RoomCode  
where RoomType <>'0'  
group by RS.RoomCode,RoomName,RS.IsForBid
go

create view VT_RoomSuperviseInfo as
select RoomCode,RoomName,  
case when (select PersonCount from VT_RoomSupervise a where IsForBid='0' and a.RoomCode =RS.RoomCode) is null then 0  
else (select PersonCount from VT_RoomSupervise b where IsForBid='0' and b.RoomCode =RS.RoomCode) end as PersonCount,  
case when (select PersonCount from VT_RoomSupervise c where IsForBid='0' and c.RoomCode =RS.RoomCode) is null then '1'  
 when (select PersonCount from VT_RoomSupervise d where IsForBid='0' and d.RoomCode =RS.RoomCode) = 0 then '1'   
else '0' end as ISForBid,  
case when (select PersonCount from VT_RoomSupervise e where IsForBid='0' and e.RoomCode =RS.RoomCode) is null then '是'  
when (select PersonCount from VT_RoomSupervise f where IsForBid='0' and f.RoomCode =RS.RoomCode) =  0 then '是'   
else '否' end as ForBid   
from  VT_RoomSupervise RS
go

create view VT_SuperviseInfo as
select SCode,MCode,MPName,PhoneNumber,
case when ReceiveTypeCode ='ET' then '所有类型'
when ReceiveTypeCode ='EW' then '每周'
else '每月' end as ReceiveTypeCode,IsForBid,
case when IsForBid ='0' then '否'
else '是' end as ForBid
from TT_Supervise
go

create view VT_TaxAssignDetail as
select a.*,b.UnitName from dbo.TT_TaxAssignDetail a
left join TT_TaxUnit b on a.UnitCode=b.UnitCode
go

create view VT_TaxItem as
select  a.*,
b.businName as ItemTypeName  from TT_TaxItem a 
left join  (select businID,businName  from SYS_Dictionary where businTypeID='1001')  b  
on a.ItemType=b.businID
go

create view VT_TempCard as
select a.*,b.BusinName as TempCardStateName from TT_TempCard a  
left join   
(select BusinID,BusinName from Sys_Dictionary where BusinTypeID='1005') b  
on a.TempCardState=b.BusinID
go

create view VT_TransferAccounts as
select TransferID,TransferMoney,Operator,OperateTime, OrgName,FromCollCode,ToCollCode,
a.CollName as FromCollName,b.CollName as ToCollName,
(Select OrgName from Sys_Organization where OrgCode=a.OrgCode) FromOrgName,
(Select OrgName from Sys_Organization where OrgCode=b.OrgCode) ToOrgName
from dbo.TT_TransferAccounts t
left join Sys_Colliery a on t.FromCollCode=a.CollCode
left join Sys_Colliery b on t.ToCollCode=b.CollCode
go

create view VT_WaterBook as
select TT_WaterBook.*,dbo.Sys_Colliery.CollName,Sys_Colliery.VillageCode,vill.businName AS VillageName from TT_WaterBook   
left JOIN dbo.Sys_Colliery ON TT_WaterBook.CollCode=dbo.Sys_Colliery.CollCode
left join
(SELECT     businID, businName
                            FROM          dbo.SYS_Dictionary
                            WHERE      (businTypeID = '1002')) AS vill ON Sys_Colliery.VillageCode = vill.businID
go

