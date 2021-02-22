from typing import Any
from client import Message
import json

CODE_LEN = 3
LENGTH_LEN = 5


def parse_message(msg: str) -> Any:
    if len(msg) < CODE_LEN + LENGTH_LEN:
        raise ValueError("Bad message format")
    try:
        code = int(msg[:CODE_LEN])
    except ValueError:
        raise ValueError("Message code should be an integer")
    try:
        data_len = int(msg[CODE_LEN : CODE_LEN + LENGTH_LEN])
    except ValueError:
        raise ValueError("Data length should be an integer")
    data = msg[CODE_LEN + LENGTH_LEN :]
    if len(data) != data_len:
        raise ValueError("Wrong message length")
    try:
        data = json.loads(data)
    except ValueError:
        raise ValueError("Data should be in json format")
    return Message(code, data)
