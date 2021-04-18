from consts import Consts
from enum import IntEnum
from typing import List
from random import random, sample
from base64 import b64encode


class CardType(IntEnum):
    NONE = 0
    BLANK = 1
    RED = 2
    BLUE = 3
    BOMB = 4

    def op(self):
        return CardType.RED if self is CardType.BLUE else CardType.BLUE


class WordCard:
    def __init__(self, word: str, type=CardType.BLANK):
        self.word = word
        self.type = type
        self.revealed = False

    def to_dict(self):
        return {
            "word": b64encode(self.word.encode()).decode(),
            "type": self.type,
            "revealed": self.revealed,
        }


class Board:
    def __init__(self, word_board: List[List[str]]):
        self.board = [
            [
                WordCard(word_board[r * Consts.BOARD_LENGTH + c])
                for c in range(Consts.BOARD_LENGTH)
            ]
            for r in range(Consts.BOARD_LENGTH)
        ]
        self.more = CardType.RED if random() >= 0.5 else CardType.BLUE
        self.random_types()

    def random_types(self):
        indexes = sample(
            range(Consts.CARDS_AMOUNT),
            Consts.BASE_TEAM_AMOUNT * 2 + 1 + Consts.BOMBS_AMOUNT,
        )
        i = 0
        for _ in range(Consts.BASE_TEAM_AMOUNT + 1):
            self.board[indexes[i] // Consts.BOARD_LENGTH][
                indexes[i] % Consts.BOARD_WIDTH
            ].type = self.more
            print(i, indexes[i] // Consts.BOARD_LENGTH, i % Consts.BOARD_WIDTH)
            i += 1
        for _ in range(Consts.BASE_TEAM_AMOUNT):
            self.board[indexes[i] // Consts.BOARD_LENGTH][
                indexes[i] % Consts.BOARD_WIDTH
            ].type = self.more.op()
            i += 1
        self.board[indexes[i] // Consts.BOARD_LENGTH][
            indexes[i] % Consts.BOARD_WIDTH
        ].type = CardType.BOMB

    def to_json(self, manager=False) -> List[List[WordCard]]:
        return [
            [
                (
                    wc if wc.revealed or manager else WordCard(wc.word, CardType.NONE)
                ).to_dict()
                for wc in r
            ]
            for r in self.board
        ]

    def __getitem__(self, row: int) -> List[WordCard]:
        return self.board[row]
