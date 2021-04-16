import random
from board import Board, CardType, WordCard
from typing import List, Union, Dict
from consts import Consts


class GameRoom:
    def __init__(self, admin: str, max_players: int):
        self.admin = admin
        self.players = [admin]
        self.max_players = max_players
        self.reds = None
        self.blues = None
        self.game_board = None
        self.started = False
        self.ended = False
        self.deleted = False
        self.turn = None
        self.curr_word = ""
        self.curr_cards = 0

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
            self.game_board = Board()
            rand_users = list(self.players)
            random.shuffle(rand_users)
            half = len(rand_users) // 2 + (
                1 if self.game_board.more == CardType.RED else 0
            )
            self.reds, self.blues = rand_users[:half], rand_users[half:]
            self.turn = self.game_board.more
            self.started = True

    def get_state(self, manager=False) -> Dict[str, Union[bool, List[List[WordCard]]]]:
        return {
            "deleted": self.deleted,
            "ended": self.ended,
            "red_turn": self.turn == CardType.RED,
            "curr_word": self.curr_word,
            "curr_cards": self.curr_cards,
            "curr_word" "board": self.game_board.tolist(manager or self.ended),
        }
