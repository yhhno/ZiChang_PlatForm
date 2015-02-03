
/*==============================================================*/    
/* View: VSYS_Dictionary                                        */    
/*==============================================================*/    
alter view dbo.VSYS_Dictionary as    
SELECT  BusinID, BusinName, a.BusinTypeID, CASE WHEN IsForbid = 1 THEN 'Ω˚”√' ELSE '∆Ù”√' END AS Status,    
     b.BusinTypeName AS TypeName,b.IsCanEdit,IsForBid    
FROM         dbo.Sys_Dictionary AS a    
left join Sys_BusinType b    
on a.BusinTypeID=b.BusinTypeID 
GO