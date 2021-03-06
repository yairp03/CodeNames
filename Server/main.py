from server import Server
from consts import Consts


def main():
    server = Server(Consts.SERVER_PORT)
    server.run()


if __name__ == "__main__":
    main()
