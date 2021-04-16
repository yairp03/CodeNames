from typing import Union
from message import Message
import json
from consts import Consts
import string


def parse_message(msg: str) -> Message:
    if len(msg) < Consts.CODE_LEN + Consts.LENGTH_LEN:
        raise ValueError("Bad message format")
    try:
        code = int(msg[: Consts.CODE_LEN])
    except ValueError:
        raise ValueError("Message code should be an integer")
    try:
        data_len = int(msg[Consts.CODE_LEN : Consts.CODE_LEN + Consts.LENGTH_LEN])
    except ValueError:
        raise ValueError("Data length should be an integer")
    data = msg[Consts.CODE_LEN + Consts.LENGTH_LEN :]
    if len(data) != data_len:
        raise ValueError("Wrong message length")
    try:
        data = json.loads(data)
    except ValueError:
        raise ValueError("Data should be in json format")
    return Message(code, data)


def validate_username(username: str) -> bool:
    for c in username:
        if not (c.isalnum() or c == "_"):
            return False
    return True


def validate_password(password: str) -> bool:
    for c in password:
        if not (c.isalnum() or c in string.punctuation):
            return False
    return True


def extract_data(data: dict, *keys) -> list:
    try:
        return [data[key] for key in keys]
    except (TypeError, KeyError):
        return []


def validate_word(word: str) -> bool:
    return 2 <= len(word) <= 15
