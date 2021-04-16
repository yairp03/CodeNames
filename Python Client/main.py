import socket


def main():
    sock = socket.socket()
    sock.connect(("localhost", 1234))
    while True:
        c, s = input("Enter message: ").split(" ", 1)
        msg = c + str(len(s)).rjust(5, "0") + s
        if msg:
            sock.send(msg.encode())
            print(sock.recv(1024))


if __name__ == "__main__":
    main()