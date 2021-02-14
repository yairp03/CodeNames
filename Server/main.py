import server as s
PORT = 1234

def main():
    server = s.Server(PORT)
    server.run()


if __name__ == "__main__":
    main()
