from consts import Consts
from enum import Enum, auto
from typing import List
from random import random, sample


class CardType(Enum):
    NONE = auto()
    BLANK = auto()
    RED = auto()
    BLUE = auto()
    BOMB = auto()

    def op(self):
        return CardType.RED if self is CardType.BLUE else CardType.BLUE


class WordCard:
    def __init__(self, word: str, type=CardType.BLANK):
        self.word = word
        self.type = type
        self.revealed = False


class Board:
    def __init__(self, word_board: List[List[str]]):
        self.board = [[WordCard(w) for w in r] for r in word_board]
        self.more = CardType.RED if random() > 0.5 else CardType.BLUE
        self.random_types()

    def random_types(self):
        indexes = sample(
            range(Consts.CARDS_AMOUNT),
            Consts.BASE_TEAM_AMOUNT * 2 + 1 + Consts.BOMBS_AMOUNT,
        )
        i = 0
        for _ in range(Consts.BASE_TEAM_AMOUNT + 1):
            self.board[indexes[i] // Consts.BOARD_LENGTH][
                i % Consts.BOARD_WIDTH
            ].type = self.more
            i += 1
        for _ in range(Consts.BASE_TEAM_AMOUNT):
            self.board[indexes[i] // Consts.BOARD_LENGTH][
                i % Consts.BOARD_WIDTH
            ].type = self.more.op()
            i += 1
        self.board[indexes[i] // Consts.BOARD_LENGTH][
            i % Consts.BOARD_WIDTH
        ].type = CardType.BOMB

    def tolist(self, manager=False) -> List[List[WordCard]]:
        if manager:
            return self.board
        return [
            [wc if wc.revealed else WordCard(wc.word, CardType.NONE) for wc in r]
            for r in self.board
        ]
