import server as s
from consts import Consts


def main():
    server = s.Server(Consts.SERVER_PORT)
    server.run()


if __name__ == "__main__":
    main()
