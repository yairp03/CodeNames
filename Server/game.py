from consts import Consts


class GameRoom:
    def __init__(self, admin, max_players):
        self.admin = admin
        self._players = [admin]
        self.max_players = max_players
        self.started = False

    def is_joinable(self) -> bool:
        return len(self._players) < self.max_players

    def add_user(self, username: str):
        self._players.append(username)

    def can_start(self) -> bool:
        return len(self._players) >= Consts.GAME_MIN_PLAYERS
