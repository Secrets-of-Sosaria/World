# Secrets of Sosaria

For instructions, see [Manual.pdf](Manual.pdf).


## Running in Docker
When the server is running in a container, we need to enforce the IP of a Game Server to be `127.0.0.1`. To do this, edit the `Info/Scripts/Settings.cs` file and set:
```
public static string S_Address = "127.0.0.1";
public static bool S_EnforceAddress = true;
```
Then, use the `docker compose` to run the server:
```
docker compose up -d
```