INSERT [SYS_MENU] ([menuID],[menuName],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[menuSEQ]) VALUES ( 's0001','行业主管','行业主管系统平台','F01','0','0','0','0',1,'s0001')
INSERT [SYS_MENU] ([menuID],[menuName],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0002','行业主管平台','0','1','s0001','s0001',1,'0','s0001.s0002')
INSERT [SYS_MENU] ([menuID],[menuName],[menuLabel],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0003','安全联网','1','0','1','s0001','s0001',1,'0','s0001.s0003')

INSERT [SYS_MENU] ([menuID],[menuName],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[menuSEQ]) VALUES ( 's0021','基本信息','基本信息','F08','0','2','s0002','s0002',1,'s0001.s0002.s0021')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[ICValue],[IsPOP],[menuSEQ]) VALUES ( 's0022','职位维护','Position/PositionList.aspx','职位维护','F08','1','3','s0002','s0021',1,'Position/PositionList.aspx','0','s0001.s0002.s0021.s0022')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0023','部门维护','Organization/OrganizationList.aspx','部门维护','F08','1','3','s0002','s0021',2,'0','s0001.s0002.s0021.s0023')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[ICValue],[IsPOP],[menuSEQ]) VALUES ( 's0024','用户维护','Operator/OperatorList.aspx','用户信息维护','F08','1','3','s0002','s0021',3,'Operator/OperatorList.aspx','0','s0001.s0002.s0021.s0024')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0025','菜单维护','Menu/MenuList.aspx','菜单维护','F08','1','3','s0002','s0021',4,'0','s0001.s0002.s0021.s0025')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0026','字典维护','Dictionary/DictionaryList.aspx','字典维护','F08','1','3','s0002','s0021',5,'0','s0001.s0002.s0021.s0026')


INSERT [SYS_MENU] ([menuID],[menuName],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[menuSEQ]) VALUES ( 's0031','短信管理','短信管理','F08','0','2','s0002','s0002',1,'s0001.s0002.s0031')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0032','已发送短信','NoteInfo/SucceedSendMessageInfo.aspx','已发送短信','F08','1','3','s0002','s0031',1,'0','s0001.s0002.s0031.s0032')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0033','待送短信','NoteInfo/ReadySendMessageInfo.aspx','待送短信','F08','1','3','s0002','s0031',1,'0','s0001.s0002.s0031.s0033')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0034','接收短信','NoteInfo/ReceiveMessageInfo.aspx','接收短信','F08','1','3','s0002','s0031',1,'0','s0001.s0002.s0031.s0034')
INSERT [SYS_MENU] ([menuID],[menuName],[menuAction],[menuLabel],[FunctionID],[isLeaf],[menuLevel],[rootID],[parentsID],[displayOrder],[IsPOP],[menuSEQ]) VALUES ( 's0035','发送失败短信','NoteInfo/FailerMessageInfo.aspx','发送失败短信','F08','1','3','s0002','s0031',1,'0','s0001.s0002.s0031.s0035')


/********************************** 添加 宋华鑫 子长 2009-10-29 *************************************/
--修改历史添加字段煤矿序列号
--SerialNo varchar(20) null

CREATE TABLE [dbo].[Sys_Colliery](
	[CollCode] [varchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[SerialNo] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[CollName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[VillageCode] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[MineOwner] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[MinePhone] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[YearOutput] [decimal](12, 2) NULL,
	[CollState] [varchar](1) COLLATE Chinese_PRC_CI_AS NULL,
	[ImageLicence] [varchar](32) COLLATE Chinese_PRC_CI_AS NULL,
	[ImageRevenue] [varchar](32) COLLATE Chinese_PRC_CI_AS NULL,
	[ImageCompetency] [varchar](32) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[IsForbid] [varchar](1) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]

/********************************** 添加 宋华鑫 子长 2009-10-29 *************************************/