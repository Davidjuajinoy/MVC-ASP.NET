﻿CREATE LOGIN [IIS APPPOOL\OdeToFood] FROM WINDOWS
GO
ALTER SERVER ROLE [dbcreator] ADD MEMBER [IIS APPPOOL\OdeToFood]
GO