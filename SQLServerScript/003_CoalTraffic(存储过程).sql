if exists (select 1
          from sysobjects
          where  id = object_id('PT_BadRecord')
          and type in ('P','PC'))
   drop procedure PT_BadRecord
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_CarInfo')
          and type in ('P','PC'))
   drop procedure PT_CarInfo
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_CarInfoUpdate')
          and type in ('P','PC'))
   drop procedure PT_CarInfoUpdate
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_CheckBang')
          and type in ('P','PC'))
   drop procedure PT_CheckBang
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_ColieryAccountJudge')
          and type in ('P','PC'))
   drop procedure PT_ColieryAccountJudge
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_EmptyWeight')
          and type in ('P','PC'))
   drop procedure PT_EmptyWeight
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_InWeight')
          and type in ('P','PC'))
   drop procedure PT_InWeight
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_LoadWeight')
          and type in ('P','PC'))
   drop procedure PT_LoadWeight
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_LoadWeightTax')
          and type in ('P','PC'))
   drop procedure PT_LoadWeightTax
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_LoadWeightUpdate')
          and type in ('P','PC'))
   drop procedure PT_LoadWeightUpdate
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_MessageInfoByCoalKind')
          and type in ('P','PC'))
   drop procedure PT_MessageInfoByCoalKind
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_MessageInfoByColliery')
          and type in ('P','PC'))
   drop procedure PT_MessageInfoByColliery
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_MessageInfoByRoom')
          and type in ('P','PC'))
   drop procedure PT_MessageInfoByRoom
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_NavicertCardJudge')
          and type in ('P','PC'))
   drop procedure PT_NavicertCardJudge
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_OutWeight')
          and type in ('P','PC'))
   drop procedure PT_OutWeight
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_OutWeightByFY')
          and type in ('P','PC'))
   drop procedure PT_OutWeightByFY
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_RealTimeInfoByColliery')
          and type in ('P','PC'))
   drop procedure PT_RealTimeInfoByColliery
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_RealTimeInfoByRoom')
          and type in ('P','PC'))
   drop procedure PT_RealTimeInfoByRoom
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_SendMarkedCard')
          and type in ('P','PC'))
   drop procedure PT_SendMarkedCard
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_StrDate')
          and type in ('P','PC'))
   drop procedure PT_StrDate
go

if exists (select 1
          from sysobjects
          where  id = object_id('PT_TransferAccounts')
          and type in ('P','PC'))
   drop procedure PT_TransferAccounts
go


create procedure PT_BadRecord (  
   @RecordID varchar(32),  
   @NavicertCode varchar(20),  
   @RoomCode varchar(10),  
   @CarNo varchar(40),  
   @Decript varchar(400),  
   @BreakDate datetime,  
   @AlarmType varchar(100),  
   @AlarmStatus varchar(1),  
   @CollCode varchar(10),  
   @FrontImage varchar(32),  
   @FrontImageContent image,  
   @BackImage varchar(32),  
   @BackImageContent image,  
   @UpImage varchar(32),  
   @UpImageContent image,  
   @RoomImage varchar(32),  
   @RoomImageContent image  
  ) as
SET XACT_ABORT ON  
begin tran trans  
insert into TT_BadRecord(RecordID,NavicertCode,RoomCode,CarNo,Decript,BreakDate,AlarmType,AlarmStatus,  
CollCode,FrontImage,BackImage,UpImage,RoomImage) values (@RecordID,@NavicertCode,@RoomCode,@CarNo,  
@Decript,@BreakDate,@AlarmType,@AlarmStatus,@CollCode,@FrontImage,@BackImage,@UpImage,@RoomImage)  
  
 --插入车前图片    
 IF(@FrontImageContent is not null and convert(VARBINARY,@FrontImageContent) <> '')    
 Begin    
  Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)    
  Values(@FrontImage,'jpg','车前图片',@FrontImageContent)    
 end    
 --插入车后图片    
 IF(@BackImageContent is not null and convert(VARBINARY,@BackImageContent) <> '')    
 begin    
  Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)    
  Values(@BackImage,'jpg','车后图片',@BackImageContent)    
 end    
 --插入车厢图片    
 IF(@UpImageContent is not null and convert(VARBINARY,@UpImageContent) <> '')    
 begin    
  Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)    
  Values(@UpImage,'jpg','车厢图片',@UpImageContent)    
 end    
 --插入室内图片    
 IF(@RoomImageContent is not null and convert(VARBINARY,@RoomImageContent) <> '')    
 begin    
  Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)    
  Values(@RoomImage,'jpg','室内图片',@RoomImageContent)    
 end    
  
select @RecordID as RecordID  
Commit tran trans
go


create procedure PT_CarInfo (        
   @CarCode varchar(20),        
   @EmptyBangTime datetime,        
   @RoomCode varchar(10),        
   @EmptyWeight decimal(12,2),        
   @MostWeight decimal(12,2),        
   @CarNo nvarchar(20),        
   @CarType nvarchar(20),        
   @CarOwnerName nvarchar(20),        
   @CarOwnerIDCard nvarchar(20),        
   @CarOwnerPhone nvarchar(20),        
   @RandomCode varchar(4),        
   @Operator nvarchar(20),        
   @BangType varchar(20),        
   @FirstImage varchar(32),        
   @FileContent Image,        
   @DriveLicense nvarchar(20),    
   @DriverName nvarchar(20),    
   @DriverIDCard nvarchar(20),    
   @DriverPhone nvarchar(20)    
  ) as
SET XACT_ABORT ON      
begin tran trans        
 Declare @FileCode varchar(32)        
         
 Declare @Count int        
 Select @Count=Count(*) From TT_CarInfo Where CarNo=@CarNo        
        
 If(@Count Is Not Null And @Count > 0) --修改        
  Begin        
   Select @CarCode=CarCode From TT_CarInfo Where CarNo=@CarNo        
   Update TT_CarInfo Set RoomCode=@RoomCode,EmptyWeight=@EmptyWeight,    
MostWeight=@MostWeight,CarType=@CarType,CarOwnerName=@CarOwnerName,    
CarOwnerIDCard=@CarOwnerIDCard,CarOwnerPhone=@CarOwnerPhone,RandomCode=@RandomCode,    
EmptyBangTime=@EmptyBangTime,Operator=@Operator,BangType=@BangType,    
DriveLicense=@DriveLicense,DriverName=@DriverName,DriverIDCard=@DriverIDCard,    
DriverPhone=@DriverPhone Where CarCode=@CarCode        
  End        
 Else        
  Begin  --添加        
   Insert Into TT_CarInfo(CarCode,EmptyWeight,MostWeight,RoomCode,CarNo,CarType,CarOwnerName,CarOwnerIDCard,CarOwnerPhone,RandomCode,EmptyBangTime,IsAuditing,Operator,BangType,FirstImage,DriveLicense,DriverName,DriverIDCard,DriverPhone)        
   Values(@CarCode,@EmptyWeight,@MostWeight,@RoomCode,@CarNo,@CarType,@CarOwnerName,@CarOwnerIDCard,@CarOwnerPhone,@RandomCode,@EmptyBangTime,'1',@Operator,@BangType,@FirstImage,@DriveLicense,@DriverName,@DriverIDCard,@DriverPhone)        
  
   declare @countImage int 
 --插入车前图片      
 IF(@FileContent is not null and convert(VARBINARY,@FileContent) <> '')      
 Begin   
  select @countImage=count(*) from SYS_FileSave where FileCode = @FirstImage
  if(@countImage = 0)
   begin
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@FirstImage,'jpg','车前图片',@FileContent) 
   end
  set @countImage = 0     
 end      
  End        
         
 Select @CarCode As CarCode        
Commit tran trans
go


create procedure PT_CarInfoUpdate (
  	@CarCode varchar(20),
  	@DriveLicense nvarchar(20),
  	@RoomCode varchar(10),
  	@CarNo nvarchar(20),
   	@CarType nvarchar(20),
   	@EmptyWeight decimal(12,2),
   	@MostWeight decimal(12,2),
  	@Operator nvarchar(20),
  	@BangType nvarchar(20),
  	@RandomCode varchar(4),
  	@EmptyBangTime datetime,
   	@CarOwnerName nvarchar(20),
   	@CarOwnerIDCard nvarchar(20),
   	@CarOwnerPhone nvarchar(20),
  	@Remark nvarchar(200),
  	@DriverName nvarchar(20),
  	@DriverIDCard nvarchar(20),
  	@DriverPhone nvarchar(20)
   ) as
SET XACT_ABORT ON
begin tran trans
	Update TT_CarInfo set RoomCode=@RoomCode,CarNo=@CarNo,CarType=@CarType,EmptyWeight=@EmptyWeight,
	MostWeight=@MostWeight,EmptyBangTime=@EmptyBangTime,Operator=@Operator,Remark=@Remark,CarOwnerName=@CarOwnerName,
	CarOwnerIDCard=@CarOwnerIDCard,CarOwnerPhone=@CarOwnerPhone,BangType=@BangType,DriveLicense=@DriveLicense,
	DriverName=@DriverName, DriverIDCard=@DriverIDCard,DriverPhone=@DriverPhone
	where CarCode=@CarCode
	 	
	Declare @Count int
	Select @Count=Count(*) From TT_Navicert Where CarCode=@CarCode
	If(@Count Is Not Null And @Count > 0) --修改
		Begin
			Update TT_Navicert Set CarNo=@CarNo,CarType=@CarType,CarOwnerName=@CarOwnerName,CarOwnerPhone=@CarOwnerPhone,MostWeight=@MostWeight,EmptyWeight=@EmptyWeight Where CarCode=@CarCode
		End	
	Select @CarCode As CarCode
Commit tran trans
go


create procedure PT_CheckBang (    
   @CheckCode varchar(20),    
   @WeightCode varchar(20),    
   @NavicertCode varchar(20),    
   @MarkedCardCode varchar(20),    
   @NetWeight decimal(12,2),    
   @RoomCode varchar(10),    
   @IsPassed varchar(1),    
   @CheckResult varchar(400),    
   @CheckTime datetime,    
   @Operator varchar(20),    
   @FrontImage varchar(32),    
   @FrontImageContent image,    
   @BackImage varchar(32),    
   @BackImageContent image,    
   @UpImage varchar(32),    
   @UpImageContent image,    
   @RoomImage varchar(32),    
   @RoomImageContent image    
  ) as
SET XACT_ABORT ON    
begin tran trans    
insert into TT_CheckBang(CheckCode,WeightCode,NavicertCode,MarkedCardCode,NetWeight,    
RoomCode,IsPassed,CheckResult,CheckTime,Operator,FrontImage,BackImage,UpImage,    
RoomImage)values (@CheckCode,@WeightCode,@NavicertCode,@MarkedCardCode,    
@NetWeight,@RoomCode,@IsPassed,@CheckResult,@CheckTime,@Operator,@FrontImage,    
@BackImage,@UpImage,@RoomImage)    
    
declare @count int 
 --插入车前图片      
 IF(@FrontImageContent is not null and convert(VARBINARY,@FrontImageContent) <> '')      
 Begin   
  select @count=count(*) from SYS_FileSave where FileCode = @FrontImage
  if(@count = 0)
   begin
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@FrontImage,'jpg','车前图片',@FrontImageContent) 
   end
  set @count = 0     
 end      
 --插入车后图片      
 IF(@BackImageContent is not null and convert(VARBINARY,@BackImageContent) <> '')      
 begin      
  select @count=count(*) from SYS_FileSave where FileCode = @BackImage
  if(@count = 0)
   begin
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@BackImage,'jpg','车后图片',@BackImageContent)
   end
  set @count = 0      
 end      
 --插入车厢图片      
 IF(@UpImageContent is not null and convert(VARBINARY,@UpImageContent) <> '')      
 begin 
  select @count=count(*) from SYS_FileSave where FileCode = @UpImage
  if(@count = 0)
   begin     
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@UpImage,'jpg','车厢图片',@UpImageContent) 
   end
  set @count = 0     
 end      
 --插入室内图片      
 IF(@RoomImageContent is not null and convert(VARBINARY,@RoomImageContent) <> '')      
 begin
  select @count=count(*) from SYS_FileSave where FileCode = @RoomImage
  if(@count = 0)
   begin       
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@RoomImage,'jpg','室内图片',@RoomImageContent)
   end
  set @count = 0      
 end      
select @CheckCode as CheckCode    
Commit tran trans
go


create procedure PT_ColieryAccountJudge (     
    @CollCode varchar(10),    
    @CoalKindCode varchar(4)      
   ) as
set nocount on      
 Declare @HaveKind int      
 Declare @ReturnValue int      
 Declare @Account decimal(14,4)      
 Declare @LowAccount decimal(14,4)        
     
 Declare @HaveColl int     
 Select @HaveColl=Count(0) from Sys_Colliery where CollCode=@CollCode and IsForBid ='0'   
 if(@HaveColl>0)    
  begin    
   Select @Account = 0.00  Select @LowAccount = 0.00       
   Select @LowAccount=isnull(LowAccount,0),@Account=isnull(Account,0) From TT_ColieryAccount Where CollCode=@CollCode      
   if(@Account>=@LowAccount)      
    Begin      
     Select @HaveKind=Count(0) From TT_CollRunCoalKind Where CollCode=@CollCode And CoalKindCode=@CoalKindCode and IsForBid='0'       
      If(@HaveKind = 0) 
		begin       
			Select @ReturnValue = 2
		end
	  else
		begin  
			Select @ReturnValue = 0  
		end     
    End      
   else  
	 begin       
	  Set @ReturnValue = 1       
	 end    
  end     
 else  
  begin    
	Select @ReturnValue =-1   
  end  
 Select @ReturnValue As ReturnValue      
 set nocount off
go


create procedure PT_EmptyWeight (    
   @EmptyCode varchar(20),    
   @CarCode varchar(20),    
    @RemoteCardCode varchar(20),    
    @NavicertCode varchar(20),    
    @EmptyWeight decimal(12,2),    
    @BangType nvarchar(20),    
    @RoomCode varchar(10),    
    @FrontImage varchar(32),    
    @Operator nvarchar(20),    
    @BangTime datetime,    
    @FrontImageContent image,    
   @CarNo varchar(20),    
   @CarOwnerName nvarchar(20),    
   @CarOwnerIDCard nvarchar(20),    
   @CarOwnerPhone nvarchar(20),    
   @RandomCode varchar(4)    
   ) as
SET XACT_ABORT ON    
begin tran trans    
 Insert Into TT_EmptyWeight(EmptyCode,CarCode,RemoteCardCode,NavicertCode,EmptyWeight,BangType,RoomCode,FrontImage,Operator,BangTime,IsLoadWeight,CarNo,CarOwnerName,CarOwnerIDCard,CarOwnerPhone,RandomCode)    
   Values(@EmptyCode,@CarCode,@RemoteCardCode,@NavicertCode,@EmptyWeight,@BangType,@RoomCode,@FrontImage,@Operator,@BangTime,'0',@CarNo,@CarOwnerName,@CarOwnerIDCard,@CarOwnerPhone,@RandomCode)    
     
 declare @countImage int 
 --插入车前图片      
 IF(@FrontImageContent is not null and convert(VARBINARY,@FrontImageContent) <> '')      
 Begin   
  select @countImage=count(*) from SYS_FileSave where FileCode = @FrontImage
  if(@countImage = 0)
   begin
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@FrontImage,'jpg','车前图片',@FrontImageContent) 
   end
  set @countImage = 0     
 end 
     
 Select @EmptyCode As EmptyCode    
Commit tran trans
go


create procedure PT_InWeight (    
  @NavicertCode varchar(20),   
  @CarNo varchar(20),    
  @CollCode varchar(50),    
  @CollName nvarchar(50),    
  @CoalKindCode varchar(50),
  @CoalKindName nvarchar(50),
  @LoadWeight decimal(12,2),
  @NetWeight decimal(12,2),
  @RoomName nvarchar(50),
 
  @Operator nvarchar(20),
  @BangType nvarchar(20),
  @BangTime datetime,
  @BangCode varchar(50),
 
  @FrontImage varchar(32),
  @BackImage varchar(32),
  @UpImage varchar(32),
  @RoomImage varchar(32),
  
  @FrontImageContent image,      
  @BackImageContent image,      
  @UpImageContent image,      
  @RoomImageContent image
   
 ) as
SET XACT_ABORT ON  
begin tran trans    
 
 
INSERT INTO dbo.TT_InWeight (NavicertCode,CarNo,CollCode,CollName,CoalKindCode,CoalKindName,
LoadWeight,NetWeight,RoomName,Operator,BangType,BangTime,BangCode,FrontImage,BackImage,UpImage,RoomImage)
 VALUES(@NavicertCode,@CarNo,@CollCode,@CollName,@CoalKindCode,@CoalKindName,@LoadWeight,
 @NetWeight,@RoomName,@Operator,@BangType,@BangTime,@BangCode,@FrontImage,@BackImage,@UpImage,@RoomImage)
      
  --插入车前图片      
  IF(@FrontImageContent is not null and convert(VARBINARY,@FrontImageContent) <> '')      
  Begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@FrontImage,'jpg','车前图片',@FrontImageContent)      
  end      
  --插入车后图片      
  IF(@BackImageContent is not null and convert(VARBINARY,@BackImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@BackImage,'jpg','车后图片',@BackImageContent)      
  end      
  --插入车厢图片      
  IF(@UpImageContent is not null and convert(VARBINARY,@UpImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@UpImage,'jpg','车厢图片',@UpImageContent)      
  end      
  --插入室内图片      
  IF(@RoomImageContent is not null and convert(VARBINARY,@RoomImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@RoomImage,'jpg','室内图片',@RoomImageContent)      
  end   
     
 Commit tran trans

SET ANSI_NULLS OFF
go


create procedure PT_LoadWeight (        
    @WeightCode varchar(20),      
    @TrafficCode varchar(20),      
    @NavicertCode varchar(20),        
    @MarkedCardCode varchar(20),      
    @RemoteCardCode varchar(20),      
    @CollCode varchar(10),      
    @CollName nvarchar(50),      
    @CoalKindCode varchar(10),      
    @CoalKindName nvarchar(20),      
    @CarOwnerName nvarchar(20),      
    @CarNo nvarchar(20),        
    @CarType nvarchar(20),      
    @LoadWeight decimal(12,2),      
    @EmptyWeight decimal(12,2),       
    @NetWeight decimal(12,2),      
    @OverWeight decimal(12,2),       
    @RoomCode varchar(10),      
    @RoomName nvarchar(50),      
    @BangType nvarchar(20),      
    @Operator nvarchar(20),      
    @WeightTime datetime,      
    @RandomCode  varchar(4),        
    @CustomerName nvarchar(20),      
    @TaxType nvarchar(20),      
    @TaxObject varchar,      
    @IsFirstSite varchar(1),      
    @FrontImage  varchar(32),      
    @BackImage  varchar(32),      
    @UpImage  varchar(32),      
    @RoomImage  varchar(32),      
    @FrontImageContent image,      
    @BackImageContent image,      
    @UpImageContent image,      
    @RoomImageContent image,      
    @EmptyCode varchar(20)      
   ) as
SET XACT_ABORT ON    
begin tran trans       
       
--计算规费      
-----------------------------------------------------------------       
 Declare @TaxMoney decimal(14,4)        
 Declare @FundMoney decimal(14,4)        
 Declare @TaxGroup  numeric(10,0)      
 --判断扣规费的对象 1：磅房 2：煤矿 3：片区    
 Declare @TaxObjectName varchar(20)      
 if(@TaxObject='1')      
  Set @TaxObjectName=@RoomCode      
 else if(@TaxObject='2')     
  Set @TaxObjectName=@CollCode   
 else if(@TaxObject='3')
	Select  @TaxObjectName=ParcelCode from Sys_Colliery where CollCode=@CollCode
         
 Select @TaxMoney = 0.00        
 Select @FundMoney = 0.00       
 Set @TaxGroup=0      
       
 --TaxGroup      
 select @TaxGroup=isnull(max(TaxGroup),0) from TT_TaxItemDetail where EffectTime<=@WeightTime and 

RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode      
      
 --TaxMoney      
 select @TaxMoney=isnull(sum(Amount),0)  from TT_TaxItemDetail      
 where TaxGroup= @TaxGroup      
 and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode      
      
 --FundMoney      
 select @FundMoney=isnull(sum(Amount),0)  from TT_TaxItemDetail      
 where TaxGroup= @TaxGroup     
 and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode      
 and TaxItemCode in       
 (      
  select TaxItemCode from TT_TaxItem        
  where ItemType in(select distinct businID from SYS_Dictionary where businName like '%价格调节基金%')      
 )      
-----------------------------------------------------------------       
      
 Declare @EndMoney decimal(14,4)      
 Declare @TradeCode varchar(20)      
  --要扣除的金额      
 Declare @Tax decimal(14,4)       
  --要扣的价格调节基金      
 Declare @Fund decimal(14,4)      
 Declare @JournalCode int      
 Select @TradeCode=IsNull(Max(TradeCode)+1,1000000001) From TT_WaterBook      
 Select @JournalCode=IsNull(Max(JournalCode)+1,1) From TT_WaterBook Where CollCode=@CollCode And JournalCode Is Not Null      
 Select @EndMoney = IsNull(Account,0.00) From TT_ColieryAccount Where CollCode=@CollCode      
        
 if(@IsFirstSite<>'1') --计算超重时要扣的税和基金      
  begin      
   Set @Tax=@TaxMoney*@OverWeight      
   Set @Fund=@FundMoney*@OverWeight      
  end      
 else --正常扣税时要扣的税和基金      
  begin      
   Set @Tax=@TaxMoney*@NetWeight      
   Set @Fund=@FundMoney*@NetWeight      
  end      
 --插入重车过磅记录       
 Insert Into TT_LoadWeight
(WeightCode,TrafficCode,NavicertCode,MarkedCardCode,RemoteCardCode,CollCode,CollName,CoalKindCode,CoalKindName,CarOwnerName,CarNo,CarType,LoadWeight,EmptyWeight,NetWeight,OverWeight,TaxAmount,FundAmount,RoomCode,RoomName,BangType,Operator,WeightTime,RandomCode,CustomerName,TaxType,IsFirstSite,FrontImage,BackImage,UpImage,RoomImage,TaxGroup,EmptyCode)        
 Values
(@WeightCode,@TrafficCode,@NavicertCode,@MarkedCardCode,@RemoteCardCode,@CollCode,@CollName,@CoalKindCode,@CoalKindName,@CarOwnerName,@CarNo,@CarType,@LoadWeight,@EmptyWeight,@NetWeight,@OverWeight,@Tax,@Fund,@RoomCode,@RoomName,@BangType,@Operator,@WeightTime,@RandomCode,@CustomerName,@TaxType,@IsFirstSite,@FrontImage,@BackImage,@UpImage,@RoomImage,@TaxGroup,@EmptyCode)       
     
 ---------------增加流水帐户记录--------------------------------------------      
 Insert Into TT_WaterBook
(TradeCode,CollCode,JournalCode,StartMoney,TradeMoney,EndMoney,Operator,TradeDate,TradeKind,WeightCode)      
  Values(@TradeCode,@CollCode,@JournalCode,@EndMoney,-@Tax,@EndMoney -@Tax,@Operator,@WeightTime,@TaxType,@WeightCode)      
 ---------------------------------------------------------------------------      
 --煤矿账户减少      
 Update TT_ColieryAccount Set Account=Account-@Tax where CollCode=@CollCode      
 --标识卡状态变为已使用      
 Update TT_MarkedCard set MarkedCardState='2' where MarkedCardCode=@MarkedCardCode and MarkedCardState='1'      
      
 declare @count int 
 --插入车前图片      
 IF(@FrontImageContent is not null and convert(VARBINARY,@FrontImageContent) <> '')      
 Begin   
  select @count=count(*) from SYS_FileSave where FileCode = @FrontImage
  if(@count = 0)
   begin
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@FrontImage,'jpg','车前图片',@FrontImageContent) 
   end
  set @count = 0     
 end      
 --插入车后图片      
 IF(@BackImageContent is not null and convert(VARBINARY,@BackImageContent) <> '')      
 begin      
  select @count=count(*) from SYS_FileSave where FileCode = @BackImage
  if(@count = 0)
   begin
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@BackImage,'jpg','车后图片',@BackImageContent)
   end
  set @count = 0      
 end      
 --插入车厢图片      
 IF(@UpImageContent is not null and convert(VARBINARY,@UpImageContent) <> '')      
 begin 
  select @count=count(*) from SYS_FileSave where FileCode = @UpImage
  if(@count = 0)
   begin     
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@UpImage,'jpg','车厢图片',@UpImageContent) 
   end
  set @count = 0     
 end      
 --插入室内图片      
 IF(@RoomImageContent is not null and convert(VARBINARY,@RoomImageContent) <> '')      
 begin
  select @count=count(*) from SYS_FileSave where FileCode = @RoomImage
  if(@count = 0)
   begin       
	Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
	Values(@RoomImage,'jpg','室内图片',@RoomImageContent)
   end
  set @count = 0      
 end      
      
 --更新空车过磅状态      
 Update TT_EmptyWeight set IsLoadWeight='1' where NavicertCode=@NavicertCode      
    
 Select @WeightCode As WeightCode     
    
 IF(@@error=0)    
 Commit tran trans
go


create procedure PT_LoadWeightTax @WeightCode varchar(20),@ItemName varchar(800) as
begin
declare @singleName varchar(800)
declare @strSql varchar(8000) 
set @strSql=''
set @strSql = '(SELECT     RoomName, WeightCode, MarkedCardCode, NavicertCode, CollName, CarNo, CoalKindName, CarOwnerName, CarType, BangType, 
                      CAST(EmptyWeight AS varchar) + '' 吨'' AS EmptyWeight, CAST(LoadWeight AS varchar) + '' 吨'' AS LoadWeight, 
                      CAST(LoadWeight - EmptyWeight AS varchar) + '' 吨'' AS NetWeight, CAST(TaxAmount AS varchar) + '' 元'' AS TaxAmount, CAST(FundAmount AS varchar) 
                      + '' 元'' AS FundAmount, WeightTime, Operator, RandomCode,'

    while charindex(',',@ItemName)<>0   
    begin   
		  select @singleName=dbo.f_split(@ItemName,',')
		set @strSql=  @strSql+ ' CAST
                          ((SELECT     ISNULL(SUM(Amount), 0) AS Expr1
                              FROM         dbo.TT_TaxItemDetail
                              WHERE     (TaxGroup =
                                                        (SELECT     ISNULL(MAX(TaxGroup), 0) AS Expr1
                                                          FROM          dbo.TT_TaxItemDetail
                                                          WHERE      (EffectTime <= a.WeightTime) AND (RoomCode = a.RoomCode) AND (CoalKindCode = a.CoalKindCode))) AND 
                                                    (RoomCode = a.RoomCode) AND (CoalKindCode = a.CoalKindCode) AND (TaxItemCode IN
                                                        (SELECT     TaxItemCode
                                                          FROM          dbo.TT_TaxItem
                                                          WHERE      (ItemType IN
                                                                                     (SELECT DISTINCT BusinID
                                                                                       FROM          dbo.Sys_Dictionary
                                                                                       WHERE      (BusinName='''+@singleName+''')))))) * (LoadWeight - EmptyWeight) AS varchar) + '' 元'' AS '''+@singleName+''','

 set   @ItemName   =   right(@ItemName,len(@ItemName)-charindex(',',@ItemName))
    end
 set   @strSql = substring(@strSql,0,(Len(@strSql)-1))

    set @strSql = @strSql + ''' FROM  dbo.VT_LoadWeight AS a where WeightCode='''+@WeightCode+''')'
exec (@strSql)
end
go


create procedure PT_LoadWeightUpdate (  
     @WeightCode varchar(20),   
     @NavicertCode varchar(20),    
     @MarkedCardCode varchar(20),  
     @RemoteCardCode varchar(20),  
     @CollCode varchar(10),  
     @CollName nvarchar(50),  
     @CoalKindCode varchar(10),  
     @CoalKindName nvarchar(20),  
     @CarOwnerName nvarchar(20),  
     @CarNo nvarchar(20),  
     @CarType nvarchar(20),  
     @LoadWeight decimal(9,2),  
     @EmptyWeight decimal(9,2),  
     @NetWeight decimal(9,2),  
     @OverWeight decimal(9,2),  
     @RoomCode varchar(10),    
     @RoomName  nvarchar(50),  
     @WeightTime varchar(20),  
     @CustomerName nvarchar(20),  
     @IsFirstSite varchar(1),  
     @Operator nvarchar(20),  
     @TaxObject varchar(1),  
     @EmptyCode varchar(20)  
    ) as
SET XACT_ABORT ON
begin tran trans   
   
--计算规费  
-----------------------------------------------------------------   
 Declare @TaxMoney decimal(14,4)    
 Declare @FundMoney decimal(14,4)    
 Declare @TaxGroup  numeric(10,0)  
 --判断扣规费的对象  
 Declare @TaxObjectName varchar(20)  
 if(@TaxObject='1')  
  Set @TaxObjectName=@RoomCode  
  else if(@TaxObject='2')     
  Set @TaxObjectName=@CollCode   
 else if(@TaxObject='3')
	Select  @TaxObjectName=ParcelCode from Sys_Colliery where CollCode=@CollCode
     
 Select @TaxMoney = 0.00    
 Select @FundMoney = 0.00   
 Set @TaxGroup=0  
   
 --GroupID  
 select @TaxGroup=isnull(max(TaxGroup),0) from TT_TaxItemDetail where EffectTime<=@WeightTime and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode  
  
 --TaxMoney  
 select @TaxMoney=isnull(sum(Amount),0)  from TT_TaxItemDetail  
 where TaxGroup= @TaxGroup 
 and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode  
  
 --FundMoney  
 select @FundMoney=isnull(sum(Amount),0)  from TT_TaxItemDetail  
 where TaxGroup= @TaxGroup 
 and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode  
 and TaxItemCode in   
 (  
  select TaxItemCode from TT_TaxItem    
  where ItemType in(select distinct businID from SYS_Dictionary where businName like '%价格调节基金%')  
 )  
-----------------------------------------------------------------    
  --要扣除的金额  
 Declare @Tax decimal(14,4)   
  --要扣的价格调节基金  
 Declare @Fund decimal(14,4)   
 if(@IsFirstSite<>'1') --计算超重时要扣的税和基金  
  begin  
   Set @Tax=@TaxMoney*@OverWeight  
   Set @Fund=@FundMoney*@OverWeight  
  end  
 else --正常扣税时要扣的税和基金  
  begin  
   Set @Tax=@TaxMoney*@NetWeight  
   Set @Fund=@FundMoney*@NetWeight  
  end  
 Declare @CollCodeOld varchar(10)  
 Declare @MarkedCardCodeOld varchar(32)  
 Declare @TaxAmountOld decimal(14,4)    
  
 select @CollCodeOld=CollCode,@MarkedCardCodeOld=MarkedCardCode,@TaxAmountOld=TaxAmount from TT_LoadWeight 
 where WeightCode=@WeightCode   
   
  Declare @EndMoney decimal(14,4)  
  Declare @TradeCode varchar(20)  
  Declare @JournalCode int  
  
 --修改重车过磅记录   
 if(@IsFirstSite='1')  
  begin  
   Update TT_LoadWeight Set NavicertCode=@NavicertCode,MarkedCardCode=@MarkedCardCode,RemoteCardCode=@RemoteCardCode,  
   CollCode=@CollCode,CollName=@CollName,CoalKindCode=@CoalKindCode,CoalKindName=@CoalKindName,CarOwnerName=@CarOwnerName,  
   CarNo=@CarNo,CarType=@CarType,LoadWeight=@LoadWeight,EmptyWeight=@EmptyWeight,NetWeight=@NetWeight,OverWeight=0,  
   TaxAmount=@Tax,FundAmount=@Fund,WeightTime=@WeightTime,  
   RoomCode=@RoomCode,RoomName=@RoomName,CustomerName=@CustomerName,TaxGroup=@TaxGroup,EmptyCode=@EmptyCode  
   where WeightCode=@WeightCode  
  end  
 else  
  begin  
   Update TT_LoadWeight Set NavicertCode=@NavicertCode,MarkedCardCode=@MarkedCardCode,RemoteCardCode=@RemoteCardCode,  
   CollCode=@CollCode,CollName=@CollName,CoalKindCode=@CoalKindCode,CoalKindName=@CoalKindName,CarOwnerName=@CarOwnerName,  
   CarNo=@CarNo,CarType=@CarType,LoadWeight=@LoadWeight,EmptyWeight=@EmptyWeight,NetWeight=0,OverWeight=@OverWeight,  
   TaxAmount=@Tax,FundAmount=@Fund,WeightTime=@WeightTime,
   RoomCode=@RoomCode,RoomName=@RoomName,CustomerName=@CustomerName,TaxGroup=@TaxGroup,EmptyCode=@EmptyCode  
   where WeightCode=@WeightCode  
  end  
  
  ---------------增加流水帐户记录--------------------------------------------  
  Select @TradeCode=IsNull(Max(TradeCode)+1,1000000001) From TT_WaterBook  
  Select @JournalCode=IsNull(Max(JournalCode)+1,1) From TT_WaterBook Where CollCode=@CollCodeOld And JournalCode Is Not Null  
  Select @EndMoney = IsNull(Account,0.00) From TT_ColieryAccount Where CollCode=@CollCodeOld  
    
  Insert Into TT_WaterBook
  (TradeCode,CollCode,JournalCode,StartMoney,TradeMoney,EndMoney,Operator,TradeDate,TradeKind,WeightCode)  
   Values(@TradeCode,@CollCodeOld,@JournalCode,@EndMoney,@TaxAmountOld,@EndMoney + @TaxAmountOld,@Operator,@WeightTime,'重车过磅修改',@WeightCode)  
  --旧的煤矿账户增加  
  Update TT_ColieryAccount Set Account=Account+@TaxAmountOld where CollCode=@CollCodeOld  
  
  Select @TradeCode=IsNull(Max(TradeCode)+1,1000000001) From TT_WaterBook  
  Select @JournalCode=IsNull(Max(JournalCode)+1,1) From TT_WaterBook Where CollCode=@CollCode And JournalCode Is Not Null  
  Select @EndMoney = IsNull(Account,0.00) From TT_ColieryAccount Where CollCode=@CollCode  
    
  Insert Into TT_WaterBook
  (TradeCode,CollCode,JournalCode,StartMoney,TradeMoney,EndMoney,Operator,TradeDate,TradeKind,WeightCode)  
   Values(@TradeCode,@CollCode,@JournalCode,@EndMoney,-@Tax,@EndMoney - @Tax,@Operator,@WeightTime,'重车过磅修改',@WeightCode)  
     
  --新煤矿账户减少  
  Update TT_ColieryAccount Set Account=Account-@Tax where CollCode=@CollCode  
     
 -------------------------------------------------------------------------------  
 if(@MarkedCardCode<>'')  
  begin  
   --旧的标识卡状态改为未使用  
   Update TT_MarkedCard set MarkedCardState='1' where MarkedCardCode=@MarkedCardCodeOld  
    
   --标识卡状态变为已使用(先修改旧的标识卡状态)  
   Update TT_MarkedCard set MarkedCardState='2' where MarkedCardCode=@MarkedCardCode  
  end  
  
 Select @WeightCode As WeightCode    
  
 IF(@@error=0)
	Commit tran trans
go


create procedure PT_MessageInfoByCoalKind (
   	@StartDate datetime,--开始时间
   	@EndDate datetime   --结束时间
   ) as
begin tran trans
	select CoalKindCode,CoalKindName,
	count(*) as CarNum,Sum(TaxAmount) as SumAmount,
	sum(NetWeight+OverWeight) as SumWeight
	from TT_loadWeight LW
	where WeightTime between @StartDate and @EndDate
	group by CoalKindCode,CoalKindName
Commit tran trans
go


create procedure PT_MessageInfoByColliery (
   	@StartDate datetime,--开始时间
   	@EndDate datetime   --结束时间
   ) as
begin tran trans
	select CollCode,CollName,CoalKindCode,CoalKindName,
	count(*) as CarNum,Sum(TaxAmount) as SumAmount,
	sum(NetWeight+OverWeight) as SumWeight
	from TT_loadWeight LW
	where WeightTime between @StartDate and @EndDate
	group by CollCode,CollName,CoalKindCode,CoalKindName
Commit tran trans
go


create procedure PT_MessageInfoByRoom (
   	@StartDate datetime,--开始时间
   	@EndDate datetime   --结束时间
   ) as
begin tran trans
	select RoomCode,RoomName,CoalKindCode,CoalKindName,
	count(*) as CarNum,Sum(TaxAmount) as SumAmount,
	sum(NetWeight+OverWeight) as SumWeight
	from TT_loadWeight LW
	where WeightTime between @StartDate and @EndDate
	group by RoomCode,RoomName,CoalKindCode,CoalKindName
Commit tran trans
go


create procedure PT_NavicertCardJudge (
    	@CarNo varchar(20),
    	@NavicertCode varchar(20)
    ) as
set nocount on
	
	Declare @ReturnValue varchar(1)
	-------------------------------------------------------------
	Declare @Count int
	Declare @CardCount int
	--判断准运卡表里是否存在该卡号
	Select @Count = Count(*) From TT_Navicert Where NavicertState in('1','2') And NavicertCode=@NavicertCode

	If(@Count <> 0)
	Begin
		Select @CardCount=Count(*) From TT_Navicert Where NavicertState in('1','2') And CarNo=@CarNo And NavicertCode=@NavicertCode

		If(@CardCount > 0)
			Select @ReturnValue = 2
		Else
			Select @ReturnValue = 0
	End
	Else
	Begin  --数据库中不存在该卡号的准运卡
		Select @CardCount=Count(*) From TT_Navicert Where NavicertState in('1','2') And CarNo=@CarNo
		If(@CardCount > 0)	
			Select @ReturnValue = 3
		Else
			Select @ReturnValue = 1
	End

	Select @ReturnValue As ReturnValue
set nocount off
go


create procedure PT_OutWeight (    
  @OutWeightCode varchar(20),    
  @OTrafficCode varchar(20),    
  @NavicertCode varchar(20),    
  @CoalKindCode varchar(10),    
  @CoalKindName nvarchar(20),    
  @CarNo nvarchar(10),     
  @CurrentWeight decimal(12,2),    
  @ONetWeight decimal(12,2),    
  @OverWeight decimal(12,2),    
 
  @TaxType varchar(20),    
  @RandomCode varchar(4),    
  @FrontImage varchar(32),      
  @BackImage varchar(32),    
  @UpImage varchar(32),    
  @RoomImage varchar(32),    
  @RoomCode varchar(4),    
  @RoomName nvarchar(20),    
  @Operator nvarchar(20),    
  @WeightTime datetime,   
  @OutType varchar(1),      
  @BangType nvarchar(50),  --20
   
  @FrontImageContent image,      
  @BackImageContent image,      
  @UpImageContent image,      
  @RoomImageContent image,  --24
 
 
  @DiveLicense nvarchar(50),  
  @CarDriverPhone nvarchar(50),  
  @EmptyWeight decimal(12,2),   
  @CarownerIDCard nvarchar(50),  
  @BillWeight decimal(12,2),   
  @IsTax varchar(1),  --30
 
  @CollName nvarchar(50),  
  @CarNoImage varchar(32),   
  @OutWeightImage varchar(32),   
  @CarNoImageContent image,   
  @OutWeightImageContent image,  
 
  
  @IsNormal nvarchar(10),  
  @SendUnits nvarchar(50),  
  @ToUnits nvarchar(50)      
 ) as
SET XACT_ABORT ON  
begin tran trans    
 Declare @TaxMoney decimal(14,4)      
 Declare @FundMoney decimal(14,4)      
 Declare @TaxGroup  numeric(10,0)    
 Set @TaxMoney = 0.00      
 Set @FundMoney = 0.00   
 --判断扣规费的对象    
 if(@IsTax='1')    
  begin  
   Set @TaxGroup=0    
   --TaxGroup    
   select @TaxGroup=isnull(max(TaxGroup),0) from TT_TaxOutItemDetail where EffectTime<=@WeightTime and  CoalKindCode=@CoalKindCode    
      
   --TaxMoney    
   select @TaxMoney=isnull(sum(Amount),0)  from TT_TaxOutItemDetail    
   where TaxGroup= @TaxGroup    
      
   --FundMoney    
   select @FundMoney=isnull(sum(Amount),0)  from TT_TaxOutItemDetail    
   where TaxGroup= @TaxGroup   
   and TaxItemCode in     
   (    
    select TaxItemCode from TT_TaxItem      
    where ItemType in(select distinct businID from SYS_Dictionary where businName like '%价格调节基金%')    
   )    
 end  
  
 INSERT INTO TT_OutLoadWeight (OutWeightCode,OTrafficCode,NavicertCode,CoalKindCode,    
CoalKindName,CarNo,CurrentWeight,ONetWeight,OverWeight,TaxType,RandomCode,FrontImage,    
BackImage,UpImage,RoomImage,RoomCode,RoomName,Operator,WeightTime,OutType,BangType,DiveLicense,CarDriverPhone,EmptyWeight,CarownerIDCard,BillWeight,CollName,IsNormal,SendUnits,ToUnits,TaxAmount,FundAmount)     
 VALUES (@OutWeightCode,@OTrafficCode,@NavicertCode,@CoalKindCode,@CoalKindName,@CarNo,    
@CurrentWeight,@ONetWeight,@OverWeight,@TaxType,@RandomCode,@FrontImage,@BackImage,    
@UpImage,@RoomImage,@RoomCode,@RoomName,@Operator,@WeightTime,@OutType,@BangType,@DiveLicense,@CarDriverPhone,@EmptyWeight,@CarownerIDCard,@BillWeight,@CollName,@IsNormal,@SendUnits,@ToUnits,@TaxMoney*@OverWeight,@FundMoney*@OverWeight)    
      
  --插入车前图片      
  IF(@FrontImageContent is not null and convert(VARBINARY,@FrontImageContent) <> '')      
  Begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@FrontImage,'jpg','车前图片',@FrontImageContent)      
  end      
  --插入车后图片      
  IF(@BackImageContent is not null and convert(VARBINARY,@BackImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@BackImage,'jpg','车后图片',@BackImageContent)      
  end      
  --插入车厢图片      
  IF(@UpImageContent is not null and convert(VARBINARY,@UpImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@UpImage,'jpg','车厢图片',@UpImageContent)      
  end      
  --插入室内图片      
  IF(@RoomImageContent is not null and convert(VARBINARY,@RoomImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@RoomImage,'jpg','室内图片',@RoomImageContent)      
  end  
  
  --插入车牌号  
  IF(@CarNoImageContent is not null and convert(VARBINARY,@CarNoImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@CarNoImage,'jpg','车牌号图片',@CarNoImageContent)     
  end    
  
  --插入过磅单  
  IF(@OutWeightImageContent is not null and convert(VARBINARY,@OutWeightImageContent) <> '')      
  begin      
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)      
   Values(@OutWeightImage,'jpg','过境原始单据',@OutWeightImageContent)     
  end    
     
  if(@OutType = '2')    
   begin    
    update TT_OutLoadWeight set OutType ='1'     
    where OTrafficCode = @OTrafficCode and OutType='0'    
   end    
  select @OutWeightCode as OutWeightCode    
 Commit tran trans
go


create procedure PT_OutWeightByFY (          
  @OutWeightCode varchar(20),          
  @OTrafficCode varchar(20),          
  @CoalKindName nvarchar(20),          
  @CarNo nvarchar(10),           
  @CurrentWeight decimal(12,2),       
  @RandomCode varchar(4),          
  @FrontImage varchar(32),            
  @BackImage varchar(32),          
  @UpImage varchar(32),          
  @RoomImage varchar(32),          
  @RoomCode varchar(4),          
  @RoomName nvarchar(20),          
  @Operator nvarchar(20),          
  @WeightTime datetime,          
  @OutType varchar(1),            
  @BangType nvarchar(50),          
  @FrontImageContent image,            
  @BackImageContent image,            
  @UpImageContent image,            
  @RoomImageContent image,        
  @CarOwnerName varchar(50),      
  @DiveLicense nvarchar(50),        
  @CarDriverPhone nvarchar(50),          
  @CarownerIDCard nvarchar(50),        
  @CollName nvarchar(50),        
  @CarNoImage varchar(32),         
  @OutWeightImage varchar(32),         
  @CarNoImageContent image,         
  @OutWeightImageContent image,
  @Customers varchar(50)      
 ) as
SET XACT_ABORT ON        
begin tran trans          
 INSERT INTO TT_OutLoadWeight (OutWeightCode,OTrafficCode,CoalKindName,CarNo,      
CurrentWeight,RandomCode,FrontImage,BackImage,UpImage,RoomImage,RoomCode,RoomName,      
Operator,WeightTime,OutType,BangType,CarOwnerName,DiveLicense,CarDriverPhone,      
CarownerIDCard,CollName,CarNoImage,OutWeightImage,Customers)           
 VALUES (@OutWeightCode,@OTrafficCode,@CoalKindName,@CarNo,@CurrentWeight,@RandomCode,      
@FrontImage,@BackImage,@UpImage,@RoomImage,@RoomCode,@RoomName,@Operator,@WeightTime,      
@OutType,@BangType,@CarOwnerName,@DiveLicense,@CarDriverPhone,@CarownerIDCard,      
@CollName,@CarNoImage,@OutWeightImage,@Customers)          
            
declare @count int   
 --插入车前图片        
 IF(@FrontImageContent is not null and convert(VARBINARY,@FrontImageContent) <> '')        
 Begin     
  select @count=count(*) from SYS_FileSave where FileCode = @FrontImage  
  if(@count = 0)  
   begin  
 Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)        
 Values(@FrontImage,'jpg','车前图片',@FrontImageContent)   
   end  
  set @count = 0       
 end        
 --插入车后图片        
 IF(@BackImageContent is not null and convert(VARBINARY,@BackImageContent) <> '')        
 begin        
  select @count=count(*) from SYS_FileSave where FileCode = @BackImage  
  if(@count = 0)  
   begin  
 Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)        
 Values(@BackImage,'jpg','车后图片',@BackImageContent)  
   end  
  set @count = 0        
 end        
 --插入车厢图片        
 IF(@UpImageContent is not null and convert(VARBINARY,@UpImageContent) <> '')        
 begin   
  select @count=count(*) from SYS_FileSave where FileCode = @UpImage  
  if(@count = 0)  
   begin       
 Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)        
 Values(@UpImage,'jpg','车厢图片',@UpImageContent)   
   end  
  set @count = 0       
 end        
 --插入室内图片        
 IF(@RoomImageContent is not null and convert(VARBINARY,@RoomImageContent) <> '')        
 begin  
  select @count=count(*) from SYS_FileSave where FileCode = @RoomImage  
  if(@count = 0)  
   begin         
 Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)        
 Values(@RoomImage,'jpg','室内图片',@RoomImageContent)  
   end  
  set @count = 0        
 end          
   --插入车牌号    
  IF(@CarNoImageContent is not null and convert(VARBINARY,@CarNoImageContent) <> '')   
  begin        
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)        
   Values(@CarNoImage,'jpg','车牌号图片',@CarNoImageContent)       
  end      
  --插入过磅单        
  IF(@OutWeightImageContent is not null and convert(VARBINARY,@OutWeightImageContent) <> '')            
  begin            
   Insert Into SYS_FileSave(FileCode,FileType,[FileName],FileContent)            
   Values(@OutWeightImage,'jpg','过境原始单据',@OutWeightImageContent)           
  end          
          
  select @OutWeightCode as OutWeightCode          
 Commit tran trans
go


create procedure PT_RealTimeInfoByColliery (  
   @StartDate datetime,--开始时间  
   @EndDate datetime   --结束时间  
  ) as
begin tran trans  
select CollCode,CollName,RoomName,CarNo,WeightTime,
Case OverWeight when 0.00 then '净重'
else '超重' end as WeightType,sum(NetWeight+OverWeight) as SumWeight
 from TT_loadWeight  
where WeightTime between @StartDate and @EndDate
group by CollCode,CollName,RoomName,CarNo,CollName,CoalKindName,WeightTime,overweight
Commit tran trans
go


create procedure PT_RealTimeInfoByRoom (  
   @StartDate datetime,--开始时间  
   @EndDate datetime   --结束时间  
  ) as
begin tran trans  
select RoomCode,RoomName,CarNo,WeightTime,
Case OverWeight when 0.00 then '净重'
else '超重' end as WeightType,sum(NetWeight+OverWeight) as SumWeight
 from TT_loadWeight  
where WeightTime between @StartDate and @EndDate
group by RoomCode,RoomName,CarNo,CollName,CoalKindName,WeightTime,overweight
Commit tran trans
go


create procedure PT_SendMarkedCard @MarkCardStart varchar(20),
   	@MarkCardEnd varchar(20),
   	@CollCode varchar(10),
   	@CoalKindCode varchar(10),
   	@SendCardDate datetime,
   	@Operator Nvarchar(20),
   	@DepartName Nvarchar(20) as
BEGIN
	SET NOCOUNT ON;
	Declare @UsedCardList varchar(300)
	Declare @UsedCardCount int	
	Declare @UsedNavicertCardCount int	
	Set @UsedCardCount=0
	Set @UsedNavicertCardCount=0

	Declare @UsedNavicertList varchar(100)
	Select @UsedCardCount=Count(MarkedCardCode),@UsedCardList='卡号:'+Min(MarkedCardCode)+' 在标识卡中已使用' From 
	TT_MarkedCard Where MarkedCardCode Between @MarkCardStart And @MarkCardEnd

	Select @UsedNavicertCardCount=Count(NavicertCode),@UsedNavicertList='卡号:'+Min(NavicertCode)+' 在准运卡已使用' 
	From TT_Navicert where NavicertCode Between @MarkCardStart And @MarkCardEnd
	if(@UsedNavicertCardCount>0)
		Set @UsedCardList=isnull(@UsedCardList,'')+isnull(@UsedNavicertList,'')
	if(@UsedCardCount=0 and @UsedNavicertCardCount=0)
	Begin

		Declare @CurrentCardCode Nvarchar(20)
		Set @CurrentCardCode = @MarkCardStart

		Declare @Diff bigint
		Select @Diff=cast(BusinName as bigint)  from Sys_Dictionary where BusinID='1' and BusinTypeID='1017'
		declare @MarkedCardNo varchar(20)
		While(Convert(bigint,@CurrentCardCode)>=@MarkCardStart And Convert(bigint,@CurrentCardCode)<=@MarkCardEnd)
		Begin	
			Set @MarkedCardNo=cast(cast(@CurrentCardCode as bigint)+@Diff as varchar(20))
			INSERT INTO TT_MarkedCard(MarkedCardCode,MarkedCardNo,CollCode,CoalKindCode,MarkedCardState,SendCardDate,Operator,DepartName) 
			Values(@CurrentCardCode,@MarkedCardNo,@CollCode,@CoalKindCode,'1',@SendCardDate,@Operator,@DepartName)
			INSERT INTO TT_MarkedCardSendRecord(MarkedCardNo,MarkedCardCode,CollCode,CoalKindCode,SendCardDate,Operator,DepartName,SendType) 
			Values (@MarkedCardNo,@CurrentCardCode,@CollCode,@CoalKindCode,@SendCardDate,@Operator,@DepartName,'购买')
			
			Set @CurrentCardCode = Convert(bigint,@CurrentCardCode) + 1	
		End
	End
	--------------------------------------------------------------------------------
	Select @UsedCardList 
END
go


create procedure PT_StrDate (   
    @RoomCode varchar(10),  
    @UserCode varchar(10)    
   ) as
set nocount on    
 Declare @RoomName varchar(50)    
 Declare @UserName varchar(20)    
  
 Select @RoomName=RoomName From dbo.TT_Room Where RoomCode=@RoomCode  
    Select @UserName=UserName From dbo.Sys_Operator Where UserCode=@UserCode  
      
    Select @RoomName As RoomName,@UserName AS UserName  
 set nocount off
go


create procedure PT_TransferAccounts (
   @FromCollCode varchar(10),
   @ToCollCode varchar(10),
   @TransferMoney decimal(14,4),
   @Operator nvarchar(20),
   @OperateTime dateTime
   ) as
SET XACT_ABORT ON
begin tran trans
Declare @OrgName nvarchar(50)
Select @OrgName=OrgName From Sys_Organization where OrgCode=(Select OrgCode from Sys_Operator where UserName=@Operator)
Insert TT_TransferAccounts Values(@FromCollCode,@ToCollCode,@TransferMoney,@Operator,@OperateTime,@OrgName)

---------------增加流水帐户记录--------------------------------------------  
Declare @TradeCode varchar(20)  
Declare @JournalCode int  
Declare @EndMoney decimal(14,4) 

Select @TradeCode=IsNull(Max(TradeCode)+1,1000000001) From TT_WaterBook  
Select @JournalCode=IsNull(Max(JournalCode)+1,1) From TT_WaterBook Where CollCode=@FromCollCode And JournalCode Is Not Null  
Select @EndMoney = IsNull(Account,0.00) From TT_ColieryAccount Where CollCode=@FromCollCode  
Insert Into TT_WaterBook(TradeCode,CollCode,JournalCode,StartMoney,TradeMoney,EndMoney,Operator,TradeDate,TradeKind,WeightCode)  
Values(@TradeCode,@FromCollCode,@JournalCode,@EndMoney,-@TransferMoney,@EndMoney - @TransferMoney,@Operator,@OperateTime,'煤矿转账','')  

Select @TradeCode=IsNull(Max(TradeCode)+1,1000000001) From TT_WaterBook  
Select @JournalCode=IsNull(Max(JournalCode)+1,1) From TT_WaterBook Where CollCode=@ToCollCode And JournalCode Is Not Null  
Select @EndMoney = IsNull(Account,0.00) From TT_ColieryAccount Where CollCode=@ToCollCode  
Insert Into TT_WaterBook(TradeCode,CollCode,JournalCode,StartMoney,TradeMoney,EndMoney,Operator,TradeDate,TradeKind,WeightCode)  
Values(@TradeCode,@ToCollCode,@JournalCode,@EndMoney,@TransferMoney,@EndMoney+@TransferMoney,@Operator,@OperateTime,'煤矿转账','') 
--------------------------------------------更新煤矿余额-------------------------------------------------
Update TT_ColieryAccount Set Account=isnull(Account,0)+@TransferMoney where CollCode=@ToCollCode
Update TT_ColieryAccount Set Account=isnull(Account,0)-@TransferMoney where CollCode=@FromCollCode 
 ---------------------------------------------------------------------------  
Select Max(TransferID) as TransferID from TT_TransferAccounts
Commit tran trans
go



ALTER procedure [dbo].[PT_LoadWeightUpdate] (  
    @WeightCode varchar(20),   
    @NavicertCode varchar(20),    
    @MarkedCardCode varchar(20),  
    @RemoteCardCode varchar(20),  
    @CollCode varchar(10),  
    @CollName nvarchar(50),  
    @CoalKindCode varchar(10),  
    @CoalKindName nvarchar(20),  
    @CarOwnerName nvarchar(20),  
    @CarNo nvarchar(20),  
    @CarType nvarchar(20),  
    @LoadWeight decimal(9,2),  
    @EmptyWeight decimal(9,2),  
    @NetWeight decimal(9,2),  
    @OverWeight decimal(9,2),  
    @RoomCode varchar(10),    
    @RoomName  nvarchar(50),  
    @WeightTime varchar(20),  
    @CustomerName nvarchar(20),  
    @IsFirstSite varchar(1),  
    @Operator nvarchar(20),  
    @TaxObject varchar(1),  
    @EmptyCode varchar(20)  
   ) as
SET XACT_ABORT ON
begin tran trans   
   
--计算规费  
-----------------------------------------------------------------   
 Declare @TaxMoney decimal(14,4)    
 Declare @FundMoney decimal(14,4)    
 Declare @TaxGroup  numeric(10,0)  
 --判断扣规费的对象  
 Declare @TaxObjectName varchar(20)  
 if(@TaxObject='1')  
  Set @TaxObjectName=@RoomCode  
  else if(@TaxObject='2')     
  Set @TaxObjectName=@CollCode   
 else if(@TaxObject='3')
	Select  @TaxObjectName=ParcelCode from Sys_Colliery where CollCode=@CollCode
     
 Select @TaxMoney = 0.00    
 Select @FundMoney = 0.00   
 Set @TaxGroup=0  
   
 --GroupID  
 select @TaxGroup=isnull(max(TaxGroup),0) from TT_TaxItemDetail where EffectTime<=@WeightTime and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode  
  
 --TaxMoney  
 select @TaxMoney=isnull(sum(Amount),0)  from TT_TaxItemDetail  
 where TaxGroup= @TaxGroup 
 and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode  
  
 --FundMoney  
 select @FundMoney=isnull(sum(Amount),0)  from TT_TaxItemDetail  
 where TaxGroup= @TaxGroup 
 and RoomCode=@TaxObjectName and CoalKindCode=@CoalKindCode  
 and TaxItemCode in   
 (  
  select TaxItemCode from TT_TaxItem    
  where ItemType in(select distinct businID from SYS_Dictionary where businName like '%价格调节基金%')  
 )  
-----------------------------------------------------------------    
  --要扣除的金额  
 Declare @Tax decimal(14,4)   
  --要扣的价格调节基金  
 Declare @Fund decimal(14,4)   
 if(@IsFirstSite<>'1') --计算超重时要扣的税和基金  
  begin  
   Set @Tax=@TaxMoney*@OverWeight  
   Set @Fund=@FundMoney*@OverWeight  
  end  
 else --正常扣税时要扣的税和基金  
  begin  
   Set @Tax=@TaxMoney*@NetWeight  
   Set @Fund=@FundMoney*@NetWeight  
  end  
 Declare @CollCodeOld varchar(10)  
 Declare @MarkedCardCodeOld varchar(32)  
 Declare @TaxAmountOld decimal(14,4)    
  
 select @CollCodeOld=CollCode,@MarkedCardCodeOld=MarkedCardCode,@TaxAmountOld=TaxAmount from TT_LoadWeight 
 where WeightCode=@WeightCode   
   
  Declare @EndMoney decimal(14,4)  
  Declare @TradeCode varchar(20)  
  Declare @JournalCode int  

 --修改重车过磅之前先备份
 Insert TT_LoadWeightBackup select *,@Operator,getdate() from TT_LoadWeight where WeightCode=@WeightCode
  
 --修改重车过磅记录   
 if(@IsFirstSite='1')  
  begin  
   Update TT_LoadWeight Set NavicertCode=@NavicertCode,MarkedCardCode=@MarkedCardCode,RemoteCardCode=@RemoteCardCode,  
   CollCode=@CollCode,CollName=@CollName,CoalKindCode=@CoalKindCode,CoalKindName=@CoalKindName,CarOwnerName=@CarOwnerName,  
   CarNo=@CarNo,CarType=@CarType,LoadWeight=@LoadWeight,EmptyWeight=@EmptyWeight,NetWeight=@NetWeight,OverWeight=0,  
   TaxAmount=@Tax,FundAmount=@Fund,WeightTime=@WeightTime,  
   RoomCode=@RoomCode,RoomName=@RoomName,CustomerName=@CustomerName,TaxGroup=@TaxGroup,EmptyCode=@EmptyCode  
   where WeightCode=@WeightCode  
  end  
 else  
  begin  
   Update TT_LoadWeight Set NavicertCode=@NavicertCode,MarkedCardCode=@MarkedCardCode,RemoteCardCode=@RemoteCardCode,  
   CollCode=@CollCode,CollName=@CollName,CoalKindCode=@CoalKindCode,CoalKindName=@CoalKindName,CarOwnerName=@CarOwnerName,  
   CarNo=@CarNo,CarType=@CarType,LoadWeight=@LoadWeight,EmptyWeight=@EmptyWeight,NetWeight=0,OverWeight=@OverWeight,  
   TaxAmount=@Tax,FundAmount=@Fund,WeightTime=@WeightTime,
   RoomCode=@RoomCode,RoomName=@RoomName,CustomerName=@CustomerName,TaxGroup=@TaxGroup,EmptyCode=@EmptyCode  
   where WeightCode=@WeightCode  
  end  
  
  ---------------增加流水帐户记录--------------------------------------------  
  Select @TradeCode=IsNull(Max(TradeCode)+1,1000000001) From TT_WaterBook  
  Select @JournalCode=IsNull(Max(JournalCode)+1,1) From TT_WaterBook Where CollCode=@CollCodeOld And JournalCode Is Not Null  
  Select @EndMoney = IsNull(Account,0.00) From TT_ColieryAccount Where CollCode=@CollCodeOld  
    
  Insert Into TT_WaterBook
  (TradeCode,CollCode,JournalCode,StartMoney,TradeMoney,EndMoney,Operator,TradeDate,TradeKind,WeightCode)  
   Values(@TradeCode,@CollCodeOld,@JournalCode,@EndMoney,@TaxAmountOld,@EndMoney + @TaxAmountOld,@Operator,@WeightTime,'重车过磅修改',@WeightCode)  
  --旧的煤矿账户增加  
  Update TT_ColieryAccount Set Account=Account+@TaxAmountOld where CollCode=@CollCodeOld  
  
  Select @TradeCode=IsNull(Max(TradeCode)+1,1000000001) From TT_WaterBook  
  Select @JournalCode=IsNull(Max(JournalCode)+1,1) From TT_WaterBook Where CollCode=@CollCode And JournalCode Is Not Null  
  Select @EndMoney = IsNull(Account,0.00) From TT_ColieryAccount Where CollCode=@CollCode  
    
  Insert Into TT_WaterBook
  (TradeCode,CollCode,JournalCode,StartMoney,TradeMoney,EndMoney,Operator,TradeDate,TradeKind,WeightCode)  
   Values(@TradeCode,@CollCode,@JournalCode,@EndMoney,-@Tax,@EndMoney - @Tax,@Operator,@WeightTime,'重车过磅修改',@WeightCode)  
     
  --新煤矿账户减少  
  Update TT_ColieryAccount Set Account=Account-@Tax where CollCode=@CollCode  
     
 -------------------------------------------------------------------------------  
 if(@MarkedCardCode<>'')  
  begin  
   --旧的标识卡状态改为未使用  
   Update TT_MarkedCard set MarkedCardState='1' where MarkedCardCode=@MarkedCardCodeOld  
    
   --标识卡状态变为已使用(先修改旧的标识卡状态)  
   Update TT_MarkedCard set MarkedCardState='2' where MarkedCardCode=@MarkedCardCode  
  end  
  
 Select @WeightCode As WeightCode    
  
 IF(@@error=0)
	Commit tran trans
GO




