﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

PRINT N'Inserting system data...';

--:r ".\ClearAllData.sql"
-- Use the following script when updating DB with system value, but willing to keep data
--:r ".\ClearSystemData.sql"

:r ".\System Data\FieldConfiguration-SystemData.sql"
:r ".\System Data\ContentConfiguration-SystemData.sql"