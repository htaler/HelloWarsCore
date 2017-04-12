# HelloWarsCore
An attempt to rewrite HelloWars server in .NET Core

HelloWars server is a simplistic online arena server, allowing participants to write their own bots to battle.

Short description of projects in solution:
- Arena.Runner - asks contenders (found in Arena server API) for next moves, updates Arena server. Game rules login pluggable.
- Arena.Server - contains current game information. Allow to join game. Allow retrieval of the current boart for visualization. Does not contain game rules logic.
