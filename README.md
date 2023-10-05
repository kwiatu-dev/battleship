# Battleship Board Game

Zapraszamy Cię do kroku rekrutacji, jakim jest wykonanie zadania w C#. Poniżej treść zadania:

Based on the rules of the Battleship board game, implement a program which randomly places ships on two boards and simulates gameplay between 2 players.

Jeśli czujesz się na siłach, możesz także utworzyć webowy frontend w jakiejś popularnej technologii (np. Angular, React, Vue). Nie zależy nam na jakichś fajerwerkach wizualnych, głównie będziemy się skupiać na ocenie kodu i Twojego procesu pisania go. Zadanie celowo jest bardzo luźno zdefiniowane, sporo decyzji i założeń należy do Ciebie. Jeśli takie decyzje/założenia wystąpią, udokumentuj proszę te miejsca i dostarcz nam info na ich temat w readme.md w repo, które wyślesz jako rozwiązanie zadania.

Proszę przeznacz maksimum dwa tygodnie na wykonanie tego zadania.

## Running

To get started, run this from the root directory:

```
npm run dev
```

## Interface
![image](https://github.com/kwiatu-dev/battleship/assets/47112432/5284dc15-4f36-4fea-922b-c7387dcb16b9)

A) Statistics updated during gameplay
B) The button that, when clicked, prompts the bot to make a move in the game
C) Current game history

## Probabilistic Strategy
The strategy employed by bots when making shooting decisions is based on probability calculation. The bot always chooses to fire at the location where the probability of a ship appearing is the highest. Under favorable conditions, the bot managed to clear the opponent's board in as few as 20 moves. In less favorable scenarios, the bot may take around 60 moves, but it is still a much better result than random shooting.
