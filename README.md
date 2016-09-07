# CityGenerator

This repository was originally created for a Tycoon-like game, which is abandoned now. As the city-generation module of the game is done, the repository was renamed and restructured to share this part of the project.

## Installation

This project requires [`dotnetcore`](https://github.com/dotnet/core/) to be installed on your machine.  
Clone the project and simply run `dotnet restore` to restore all needed packages of the project.

## Usage

The heart of the city generation library is the [`CityGenerator`](/src/City/CityGenerator.cs) class which contains a single public static method for generating a city.

### BuildCity

`BuildCity()` takes up to four arguments, namely `width`, `height`, `seed` and optionally `config`. To generate a 30x30 city, run the method like this:
> *Note:* Using the same seed will always grant the same city as a result.

    City.City c = CityGenerator.BuildCity(30, 30, 921993);

To get a string-representation of this city, use `ToString()`. This will render all buildings like the following (including the linebreaks):

	##############################
	OO#OOOO#.OOO#OOO#OOOO#O.#OO#OO
	OO#SOOO#O**O#O*O#OO*O#OO#OO#OO
	OO###OO#O**O#P*O##O*O#########
	OOOO#OO#O**O#O*SO#.*OO#OO#OO#O
	O**O#PO#O*OH#OOOO#OOO.#OO#OO#O
	P**O#OO#O*O##OO#####OO########
	O**O#OO#O*O#OOO#OOO#OOO#OOO#OO
	OO.O#..#OOO#O*O#O*O#OOO#OOO#OO
	OO###.O#OO##S*O#O*O##OO#######
	OO#OPOO#OO#OO*O#O*OO#.OOO#OOO#
	OO#OO.O#OO#O*OO#OOOO#O*OO#OOO#
	OO###OO####.*O####OO#.*O##..##
	OOOO#OO.O#OO*O#OO#OO#O*O#OOO#S
	O**.#O*O.#HOOO#OH#OO#OOO#OO.#O
	.**.#.*.##OO###OO#OO##########
	O**O#O*O#O..#OOOO#OOO.#OOO#OO#
	OOOO#OPO#OOO#OOOO#OOHO#OOO#OO#
	OO#######OO##OO###OO####OO####
	OO#OOO#OOOO#OOO#.OOO#OS#OOO#OO
	OO#OOO#OOSO#OOO#OOOO#OO#.*.#OO
	O.#OO####OO#OO####OO####O*O#OO
	.O#OO#OO#.O#HO#OO#OHOO#OO*O#OO
	OO#O.#OO#OO#HO#OO#OO.O#OOHO#OO
	OO####OO####OO#.O#OO#####OO###
	OO.O#O.OO#O.OO#OO#OO#OOO#OOO#O
	O**O#O**O#OOOO#OO#OO#O*O#OOO#P
	O**O#O**O#OO######OO#.*O##OO##
	O**O#O**O#OO#OO#OOOO#O*OO#OOO#
	OOOO#OOOS#OO#OO#OOOS#O.OO#OO.#
	##############################
	
#### Config

You can define the probability of buildings spawning in a Dictionary. This is the default configuration:

Building Name | Chance to spawn
--- | ---
Hospital | 10
PoliceStation | 10
Office | 80
School | 15

The numbers resemble the probability as `Chance to Spawn / 1000`. That means a Hospital may spawn in 10 of 1000 cases. To increase or lower the probability, change the value of `generatorRange`.
