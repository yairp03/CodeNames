from consts import code_to_string


class Message:
    def __init__(self, code=0, data=""):
        self.code = code
        self.data = data

    def __str__(self):
        return f"{code_to_string(self.code)}: {str(str(self.data).encode())[1:]}"

    def __bool__(self):
        return self.code != 0