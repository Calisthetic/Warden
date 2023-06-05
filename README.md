<h1 align=center>Warden</h1>

### local

```bash
Scaffold-DbContext "Server=DESKTOP-GJJERNN;Database=Warden;Trusted_Connection=true;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
```

### with password

```bash
Scaffold-DbContext "Data Source=192.168.0.117\SQLEXPRESS;Initial Catalog=db_name;User ID=User;Password=db_password;Trusted_Connection=true;TrustServerCertificate=true;Integrated Security=false;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
```

[![forthebadge](https://forthebadge.com/images/badges/ages-18.svg)](https://forthebadge.com)