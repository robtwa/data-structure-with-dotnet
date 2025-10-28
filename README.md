# how to run test

In the root folder of project, run following

```bash
dotnet test tests/unitTests -v n
```

# Test the controller with Command Line HTTP Read-Eval-Print Loop (REPL)

Open the existing httprepl terminal, or open a new integrated terminal from Visual Studio Code by selecting Terminal > New Terminal from the main menu.

Connect to our web API by running the following command:
```bash
httprepl https://localhost:{PORT}
```

Alternatively, run the following command at any time while HttpRepl is running:

```bash
connect https://localhost:{PORT}
```

To see the newly available Pizza endpoint, run the following command:

```bash
ls
```

The preceding command detects all APIs available on the connected endpoint. It should display the following code:

```bash
 https://localhost:{PORT}/> ls
 .                 []
 Pizza             [GET]
 WeatherForecast   [GET]
```

Go to the Pizza endpoint by running the following command:

```bash
cd Pizza
```

The preceding command shows an output of available APIs for the Pizza endpoint:

```bash
https://localhost:{PORT}/>
cd Pizza
/Pizza    [GET]
```

Make a GET request in HttpRepl by using the following command:

```bash
get
```

Make a POST request to add a new pizza in HttpRepl by using the following command:

```bash
post -c "{"name":"Hawaii", "isGlutenFree":false}"
```


Update the new Hawaii pizza to a Hawaiian pizza with a PUT request by using the following command:

```bash
put 3 -c  "{"id": 3, "name":"Hawaiian", "isGlutenFree":false}"

```

Our API can also delete the newly created pizza through the DELETE action if you run the following command:

```bash
delete 3

```

