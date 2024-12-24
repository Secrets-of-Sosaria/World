# Secrets of Sosaria

For instructions, see [Manual.pdf](Manual.pdf).

<<<<<<< HEAD

## Running in Docker
When the server is running in a container, we need to enforce the IP of a Game Server to be `127.0.0.1` ( for local development ), or a public IP while running on a VPS.
### Running locally
Edit the `Info/Scripts/Settings.cs` file and set:
```
public static string S_Address = "127.0.0.1";
public static bool S_EnforceAddress = true;
```
Then, use the `docker compose` to run the server:
```
docker compose up -d
```
### Running on a VPS/VDS
Edit the `Info/Scripts/Settings.cs` file and set:
```
public static string S_Address = "<SERVER PUBLIC IP>";
public static bool S_EnforceAddress = true;
```
Then, use the `docker compose` to run the server:
```
docker compose up -d
```
=======
# Secrets of Sosaria - Vision Statement

Secrets of Sosaria is an enhanced fork of the Ruins & Riches (later continued as Adventurers of Akalabeth) project. We aim to continue the tradition of this project while also introducing improvements and additional content where we feel it would enhance the experience. Our main goals are as follows:

[Short Term Goals]

- Preservation and continuation of the core Ruins & Riches/Adventurers of Akalabeth experience. The "core experience" includes basic gameplay, game world setting, and lore.
- Fixing long-standing bugs.
- Fixing inconsistencies with how parts of the game function, especially when that affects player experience.
- Improvements to game systems, especially where we can increase the appeal of interacting with ones that weren't fully fleshed out, or which were made to feel redundant by other aspects of the game.
- Identifying and reworking instances of "hostile design" that only provide tedium to the player instead of a sense of accomplishment.

[Long Term Goals]

- The introduction of new content that fits the aesthetic and themes of the game world.

[Target Audience]

The target audience is new players who are interested in an experience that takes its inspiration from tabletop roleplaying games as well as classic computer RPGs of the 1980s and 1990s. Additionally, it is intended for former players of Ruins & Riches and any of its previous forks who would like to play something further refined as a more streamlined, player-friendly, bugfixed and, eventually, more content-rich version of the game that they've come to love.

[Why Choose Secrets of Sosaria?]

The source for our world package is freely available on github and we are open to taking suggestions from the community and potentially implementing them, so long as they align with our vision. We frequently update the game, and we have a friendly and growing community of players both on our live server (Multiverset) as well as those who play their own personal solo servers.

[Conclusion]

We seek to honor the legacy of the original developers and caretakers of this game while also making it a more engaging, cohesive, and most importantly fun experience for all. While we are just one fork among many of this project, we wish to provide the best possible user experience through utilizing the methods outlined in our goals.
>>>>>>> main
