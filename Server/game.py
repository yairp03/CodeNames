from database import Database
import random
from board import Board, CardType, WordCard
from typing import List, Union, Dict
from consts import Consts
from math import ceil
from base64 import b64encode


class GameRoom:
    def __init__(self, host: str, max_players: int):
        self.host = host
        self.players = [host]
        self.max_players = max_players
        self.reds = None
        self.blues = None
        self.game_board = None
        self.remains = None
        self.started = False
        self.winner = CardType.NONE
        self.deleted = False
        self.turn = None
        self.curr_word = ""
        self.curr_cards = 0
        self.curr_revealed = 0

    def is_joinable(self) -> bool:
        return len(self.players) < self.max_players

    def add_user(self, username: str):
        self.players.append(username)

    def can_start(self) -> bool:
        return len(self.players) >= Consts.GAME_MIN_PLAYERS

    def get_players_list(self) -> List[str]:
        return self.players

    def start(self):
        if self.can_start():
            self.game_board = Board(Database.get_words(Consts.CARDS_AMOUNT))
            self.remains = {
                CardType.RED: Consts.BASE_TEAM_AMOUNT,
                CardType.BLUE: Consts.BASE_TEAM_AMOUNT,
                CardType.BLANK: Consts.BLANK_AMOUNT,
                CardType.BOMB: Consts.BOMBS_AMOUNT,
            }
            self.remains[self.game_board.more] += 1
            rand_users = list(self.players)
            random.shuffle(rand_users)
            half = ceil(len(rand_users) / 2)
            self.reds, self.blues = rand_users[:half], rand_users[half:]
            self.turn = self.game_board.more
            self.started = True

    def get_teams(self) -> Dict[str, List[str]]:
        return {"reds": self.reds, "blues": self.blues}

    def get_state(self, manager=False) -> Dict[str, Union[bool, List[List[WordCard]]]]:
        return {
            "deleted": self.deleted,
            "winner": self.winner,
            "turn": self.turn,
            "curr_word": b64encode(self.curr_word.encode()).decode(),
            "curr_revealed": self.curr_revealed,
            "curr_cards": self.curr_cards,
            "board": self.game_board.to_json(manager or self.deleted),
        }

    def which_team(self, username: str):
        return CardType.RED if username in self.reds else CardType.BLUE

    def is_manager(self, username: str, team: CardType):
        return username == (self.reds if team == CardType.RED else self.blues)[0]

    def is_revealed(self, row: int, column: int):
        return self.game_board[row][column].revealed

    def reveal_card(self, row: int, column: int):
        card = self.game_board[row][column]
        card.revealed = True
        self.remains[card.type] -= 1
        if card.type == self.turn:
            self.curr_revealed += 1
            if self.curr_revealed == self.curr_cards:
                if self.remains[self.turn] == 0:
                    self.winner = self.turn
                    self.deleted = True
                else:
                    self.switch_turn()
        elif card.type == CardType.BOMB:
            self.winner = self.turn.op()
            self.deleted = True
        elif card.type == self.turn.op() and self.remains[card.type] == 0:
            self.winner = card.type
            self.deleted = True
        else:
            self.switch_turn()

    def switch_turn(self):
        self.curr_word = ""
        self.curr_revealed = 0
        self.curr_cards = 0
        self.turn = self.turn.op()

    def update_word(self, word: str, amount: int):
        self.curr_word = word
        self.curr_cards = amount
