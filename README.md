# CookBook

## O projekcie

Projekt składa się z kilku części:

- server
- client
- client-generator
- logger

**Server** udostępnia proste w obsłudze rest api pozwalające stworzyć prostą książkę kucharską.
Jednocześnie pozwalając on możliwość logowania oraz tworzenia nowych użytkowników. System autoryzacji oparty jest o JWT token. Wszystkie przepisy są pobierana z zewnętrznego api _spoonacular_.

**Client** jest stroną internetową konsumującą api wystawione przez serwer. Posiada on równie autorski grid system, podobny do tego znanego z na przykład boostrapa.

**Client Generator** program służący do generowania type scriptowego kod, pozwalającego na połączenie się z api. Klient jest genrowany na podstawie pliku json w standardzie [openApi](https://www.openapis.org/). Posiada on również proste terminalowe GUI.

**Logger** prosta biblioteka do zapisywania/wyświetlania logów.

Server jak i client-generator napisane są z myślą o wielu wersjach. Dlatego też występuje w nich kod wersjonowany, czyli kod który powininen być wykorzystany tylko z daną wersją.
Serwer aktualnie udostępnia `v1` api a client-generator jest kompatybilny z `openApi 3.0.1`.

## Technologie

|                  |    Język     |                      Frameworki/Biblioteki                      |
| :--------------: | :----------: | :-------------------------------------------------------------: |
|      server      |      C#      | ASP.CORE, EntityFramework, Swagger, AutoMapper, FluentValidator |
|      client      | JS, TS, SASS |                   React, Redux, React-Router                    |
| client-generator |      C#      |                           T4, Gui.cs                            |
|      logger      |      C#      |                                                                 |

## Wykorzystane wzorce projektowe

- Dependency injection - pozwala usunąć bezpośrednie zależności. Wykorzystany po stronie serwera.
- Singleton - pozwala na łatwy dostęp do klas takich jak 'AppController', który zarządza GUI. Jednocześnie ogranicza liczbę tworzonych obiektów, które nie trzymają żadnego stanu (często wykorzystywane w 'aps.core'). Przykład: [AppController](https://github.com/lukmccall/CookBook/blob/master/client-generator/App/AppController.cs), [VersionedDeserializers](https://github.com/lukmccall/CookBook/blob/master/client-generator/Deserializer/VersionedDeserializers.cs), [CacheService](https://github.com/lukmccall/CookBook/blob/1b28f04afbbe0281e1a8c97bdd06ab4e1e2b716d/server/Installers/CacheInstaller.cs#L25)
- Abstract Factory - do wygenerowania kodu klienta, używamy T4 (template engine). W celu dodania abstrakcji po między generowanym kodem a jego modelem, stworzyliśmy fabrykę abstrakcyjną. Przy jej pomocy w łatwy sposób możemy otrzymać odpowiedni szablon. Co więcej zmiana szablonu na inny jest bardzo prosta. Przykład: [TemplatesFactory](https://github.com/lukmccall/CookBook/blob/master/client-generator/Templates/TemplatesFactory.cs)
- Delegation pattern - wyżej wspomniana fabryka jest tak naprawdę połączeniem kilku mniejszych klas produkujących szablony odpowiedniego typu (rozumianego jako template dopasowany do odpowiedniego modelu). Do stworzenia takiej abstrakcji użyliśmy delegata. Dzięki temu zyskujemy jeszcze większą możliwość podmienienia odpowiednich szablonów. Przykład: [ITemplateFactory](https://github.com/lukmccall/CookBook/blob/master/client-generator/Templates/ITemplateFactory.cs).
- Chain of Responsibility - architektura loggera opiera się właśnie na tym wzorcu projektowym. Pozwala on na dodawanie stopnia ważność danego logu. Przykład: [AbstractLogger](https://github.com/lukmccall/CookBook/blob/master/logger/AbstractLogger.cs).
- Command - wykorzystany do obsługi wejścia użytkownika w generatorze. Dzięki niemu mogliśmy oddzielić input od faktycznej akcji. Co zwiększyło możliwość ponownego wykorzystania kodu. Przykład: [ICommand](https://github.com/lukmccall/CookBook/blob/master/client-generator/App/Commands/ICommand.cs).
- Iterator - pozwolił na łatwą iteracje po wszystkich typach w danym 'assembly'. Przykład: [OpenApiDeserializerAssemblyIterator](https://github.com/lukmccall/CookBook/blob/master/client-generator/Deserializer/Helpers/OpenApiDeserializerAssemblyIterator.cs).
- Builder - konstrukcja modelu openApi z wejściowego pliku json nie należy do prostych zadań. Jest ona wieloczęściowa oraz wymaga dużej liczby elementów pośrednich. Dlatego też zdecydowaliśmy się na napisanie budowniczego do tej właśnie klasy. Przykład: [OpenApiModel](https://github.com/lukmccall/CookBook/blob/master/client-generator/Models/OpenApiModel.cs).
- Composite & Visitor - plik openApi po sparsowaniu ma strukturę drzewiastą (wynikającą z możliwych referencji), dlatego też do wyciągania odpowiednich informacji zdecydowaliśmy się na połączenie kompozytu z wizytorem. Dzięki kompozytowi mogliśmy w łatwy sposób poruszać się po drzewie. Natomiast za pomaca wizytora w łatwy sposób przetworzyliśmy interesujące nas elementy. Przykład: [ReferableCollector](https://github.com/lukmccall/CookBook/blob/master/client-generator/OpenApi/3.0.1/Deserializer/ReferableCollector.cs), [ICollectable](https://github.com/lukmccall/CookBook/blob/master/client-generator/Deserializer/Helpers/Collectors/ICollectable.cs).
- State - przejścia pomiędzy odpowiednimi stanami aplikacji generatora, opierają się na tym wzorcu projektowych. Jest on połączony z głównym okienkiem. Od aktualnego stanu zależy aktualnie wyświetlana zawartość. Przykład: [IMenuWindowState](https://github.com/lukmccall/CookBook/blob/master/client-generator/App/Windows/MenuWindowStates/IMenuWindowState.cs), [MenuWindow](https://github.com/lukmccall/CookBook/blob/master/client-generator/App/Windows/MenuWindow.cs).
- Strategy - używany w wielu miejscach. Na przykład w loggerze w celu oddzieleniu miejsc, do których logi mają trafić (na konsole czy do pliku). Przykład: [ILogStrategy](https://github.com/lukmccall/CookBook/blob/master/logger/LogStrategies/ILogStrategy.cs), [IGeneratorFileStrategy](https://github.com/lukmccall/CookBook/blob/master/client-generator/Generators/FilesStrategies/IGeneratorFileStrategy.cs).
- Facade - użyta w loggerze. Ułatwia korzystanie z tej funkcjonalności. Przykład: [LoggerFacade](https://github.com/lukmccall/CookBook/blob/master/logger/LoggerFacade.cs).
- Template Method - ostateczny obiekt generatora korzysta z tego wzorca. Pozwala on na łatwą modyfikację poszczególnych kroków. Użyty zamiast strategi ponieważ każdy generatory posiadają wspólną bazę i dzięki temu podejściu łatwiej ją współdzielić. Przykład: [GeneratorTemplate](https://github.com/lukmccall/CookBook/blob/master/client-generator/Generators/GeneratorTemplate.cs).

## Instalacja

### Wymagania

- `.net core v3`
- `npm` lub `yarn`

### Client

#### Instalacja

W folderze `client`, wykonaj:

```
npm install
```

lub

```
yarn
```

#### Uruchomienie

```
npm start
```

lub

```
yarn start
```

#### Docker

Baza danych (myslq i redis) z phpmyadmin jest postawiona na dockerze.
Dane do logowania znajdują się w `docker-compose.yml`.
Baza danych trzymana jest w folderze mysql - to znaczy, że dane nie są kasowane. Jendak pliki te nie są chwilowo commitowane, aby nie tworzyć konfliktów.

#### Start

```
docker-compose up -d
```

#### Stop

```
docker-compose down
```

### Baza danych mysql

Obsługiwana za pomocą `EnitityFrameworku`

#### Start

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

#### Server/Client-Generator

Odtwórz projekt za pomocą Ridera lub Visiual Studio. Konfigurację uruchomieniowe powinna automatycznie dodać się do twojego środowiska.

> **Uwaga** client-generator wymaga Ridera w wersji `2019.3`. Przyczyną jest wsparcia dla `T4`.
