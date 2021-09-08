# ASP.NET REST API Sample
### Developed by:
- **Bartolomeo Caruso**

---

## 1. NuGet Packages
- **Microsoft.AspNetCore.Authentication.JwtBearer**
- **Microsoft.AspNetCore.Identity**
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.Tools**
- **Microsoft.EntityFrameworkCore.SqlServer**

---

## 2. Useful commands
- **Migration**
    ```bash
        Add-Migration MigrationClassName
    ```
- **Remove Migration**
    ```bash
        Remove-Migration
    ```
- **Update database**
    ```bash
        Update-Database
    ```

## 3. Exposed endpoints
- **[POST] localhost:5001/login** -- Login endpoint
- **[POST] localhost:5001/register** -- User registation endpoint
- **[POST] localhost:5001/register-admin** -- Admin registation endpoint
