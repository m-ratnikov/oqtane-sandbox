/*  
Create QBCustomer table
*/

CREATE TABLE [dbo].[QBCustomer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[LastName] [nvarchar](256),
	[Address] [nvarchar](256),
	[City] [nvarchar](256),
	[State] [nvarchar](256),
	[Zip] [nvarchar](256),

	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_QBCustomer] PRIMARY KEY CLUSTERED 
  (
	[CustomerId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[QBCustomer] WITH CHECK ADD CONSTRAINT [FK_QBCustomer_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO