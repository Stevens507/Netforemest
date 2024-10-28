# Netforemost
## Prueba Técnica

### Errores Técnicos Identificados

1. **Falta de ID en el Registro de Usuario**: 
   En la función de registro de usuario, no se asigne correctamente el `Id` del usuario. Se debe agregar el `Username` al momento de crear el nuevo usuario:
   ```csharp
   users.Add(new User { Id = id, Username = username, Password = password });


2. **clase TASKitem error dde ortografia Duedata a DueDate**
public DateTime DueDate { get; set; }


**el formato para poner la fecha de vencimiento es (yyyy-mm-dd)**
