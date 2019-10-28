
                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

In package manager 
Get Help
		get-help entityframeworkcore

Pdate DB Script (Idempotent can be applied multiple times without changing the result beyond the initial application)
Script-Migration -Idempotent

How to add logging
https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging?tabs=v3


?? Object tracking
http://trackableentities.github.io/

Testing
Install-package Microsoft.EntityFrameworkCore.InMemory
Install-Package NUnit 
Install-Package NUnit3TestAdapter