# Evidencia del uso de TDD en la reparación de bugs de backend

Quisimos corregir dos bugs de backend para realizar TDD al reaprarlos. 

Al realizar la etapa red de la reparacion del bug "Error en incremento de stock al aceptar solicitud de stock", nos dimos cuenta que no era un bug ya que el incremento de stock se realizaba correctamente. Nos dimos cuenta que creimos que era un bug por como están nombradas las variables y cómo se utilizan. Podemos concluir que el uso de una documentación clara, o el nombramiento correcto de las variables es muy importante.

Por otra parte, sí realizamos TDD para reparar el bug "Validación incorrecta al actualizar invitación". Aquí dejamos evidencia del uso de TDD al reparar el bug.

## Etapa RED

En esta etapa se creó el test de la funcionalidad que se quiere reparar para evidenciar que no está funcionando correctamente. Se corrió el test y se puede ver como no pasó.

![Test en rojo](https://i.imgur.com/ufQBmm8.jpg)

Dejamos aqui tambien cómo se encontraba el código antes de ser reparado.

```C++
public Invitation UpdateInvitation(int id, Invitation invitation)
        {
            var invitationEntity = _invitationRepository.GetOneDetailByExpression(expression => expression.Id == id);
            if (invitationEntity == null) throw new ResourceNotFoundException("Invalid Invitation.");
            if (invitationEntity.IsActive == false) throw new InvalidResourceException("Invitation is not active.");

            if (invitation.Role != null)
            {
                if (string.IsNullOrEmpty(invitation.Role.Name)) throw new InvalidResourceException("Invalid Role.");
                var role = _roleRepository.GetOneByExpression(expression => expression.Name == invitation.Role.Name);
                if (role == null) throw new ResourceNotFoundException("Invalid role.");

                if (!invitation.Role.Name.Equals("Administrator"))
                {
                    if (invitation.Pharmacy is null) throw new InvalidResourceException("A Pharmacy is required.");
                }
                else
                {
                    if (invitation.Pharmacy != null) throw new InvalidResourceException("A Pharmacy is not required.");
                }

                invitationEntity.Role = role;
            }

            if (!string.IsNullOrEmpty(invitation.UserName))
            {
                var alreadyExist = _invitationRepository.GetOneByExpression(userExpression => userExpression.UserName == invitation.UserName);
                if (alreadyExist != null)
                {
                    if (alreadyExist.Id != id) throw new InvalidResourceException("UserName already exist.");
                }

                invitationEntity.UserName = invitation.UserName;
            }

            if (invitation.Pharmacy != null)
            {
                if (string.IsNullOrEmpty(invitation.Pharmacy.Name)) throw new InvalidResourceException("Invalid Pharmacy.");
                var pharmacy = _pharmacyRepository.GetOneByExpression(expression => expression.Name == invitation.Pharmacy.Name);
                if (pharmacy == null) throw new ResourceNotFoundException("Invalid Pharmacy.");
                invitationEntity.Pharmacy = pharmacy;
            }
            else
            {
                invitationEntity.Pharmacy = null;
            }

            if (!string.IsNullOrEmpty(invitation.UserCode))
                invitationEntity.UserCode = invitation.UserCode;

            _invitationRepository.UpdateOne(invitationEntity);
            _invitationRepository.Save();

            return invitationEntity;
        }
```

## Etapa GREEN

Para esta etapa se agregó el mínimo codigo necesario para que el test pase.

Dejamos aquí el código modificado.

```C++
public Invitation UpdateInvitation(int id, Invitation invitation)
        {
            var invitationEntity = _invitationRepository.GetOneDetailByExpression(expression => expression.Id == id);
            if (invitationEntity == null) throw new ResourceNotFoundException("Invalid Invitation.");
            if (invitationEntity.IsActive == false) throw new InvalidResourceException("Invitation is not active.");

            if (invitation.Role != null)
            {
                if (string.IsNullOrEmpty(invitation.Role.Name)) throw new InvalidResourceException("Invalid Role.");
                var role = _roleRepository.GetOneByExpression(expression => expression.Name == invitation.Role.Name);
                if (role == null) throw new ResourceNotFoundException("Invalid role.");

                if (invitationEntity.Role.Name.Equals("Administrator") && !invitation.Role.Name.Equals("Administrator"))
                {
                    if (invitation.Pharmacy == null) throw new InvalidResourceException("A Pharmacy is required.");
                }
                if (invitation.Role.Name.Equals("Administrator"))
                {
                    if (invitation.Pharmacy != null) throw new InvalidResourceException("A Pharmacy is not required.");
                }

                invitationEntity.Role = role;
            }

            if (!string.IsNullOrEmpty(invitation.UserName))
            {
                var alreadyExist = _invitationRepository.GetOneByExpression(userExpression => userExpression.UserName == invitation.UserName);
                if (alreadyExist != null)
                {
                    if (alreadyExist.Id != id) throw new InvalidResourceException("UserName already exist.");
                }

                invitationEntity.UserName = invitation.UserName;
            }

            if (invitation.Pharmacy != null)
            {
                if (string.IsNullOrEmpty(invitation.Pharmacy.Name)) throw new InvalidResourceException("Invalid Pharmacy.");
                var pharmacy = _pharmacyRepository.GetOneByExpression(expression => expression.Name == invitation.Pharmacy.Name);
                if (pharmacy == null) throw new ResourceNotFoundException("Invalid Pharmacy.");
                invitationEntity.Pharmacy = pharmacy;
            }
            else if (invitationEntity.Role.Name.Equals("Administrator"))
            {
                invitationEntity.Pharmacy = null;
            }

            if (!string.IsNullOrEmpty(invitation.UserCode))
                invitationEntity.UserCode = invitation.UserCode;

            _invitationRepository.UpdateOne(invitationEntity);
            _invitationRepository.Save();

            return invitationEntity;
        }
```

Y evidencia de que el test finalmente pasa con estos cambios en el código.

![Test en verde](https://i.imgur.com/xCFzbfN.png)

## Refactor

Para esta última etapa no fue necesario realizar ningún cambio ya que el código que se agregó no fue un bloque nuevo de código, sino que fueron pequeñas líneas. Por lo tanto no fue necesario realizar ningún refactor.