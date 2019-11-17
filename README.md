## Eloooo

### Docker

Baza danych z phpmyadmin jest postawiona na dockerze.
Dane do logowania znajdują się w `docker-compose.yml`.
Baza danych trzymana jest w folderze mysql - to znaczy, że dane nie są kasowane. Jendak pliki te nie są chwilowo commitowane, aby nie tworzyć konfliktów. Gdy będziemy mieli jakąś bazę może wtedy je dodamy,

#### Start

```
docker-compose up -d
```

#### Stop

```
docker-compose down
```

### Baza danych

Będziemy korzystali z `EnitityFrameworka`. Obługuję się go przez konsolkę.

```
dotnet ef
```

#### Update bazy danych (należy wykonać na samym początku)

```
dotnet ef database update
```

#### Tworzenie migracji

```
dotnet ef migrations add <nazwa>
```

#### Usuwanie ostaniej migracji

```
dotnet ef migrations remove
```

#### Znane błędy

- `Could not execute because the specified command or file was not found.`
  - należ wykonać `dotnet tool install -g dotnet-ef`

### System logowania

Będziemy korzystali z `JWT`.

### Road Map

- [x] Setup
- [x] Integracja z `EntityFramwork`
- [x] Integracja z `AspNetCore.JWT`
- [ ] Baza danych
  - [x] Dodanie `Usera`
- [ ] JWT
