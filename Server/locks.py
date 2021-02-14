import threading
from datetime import datetime

print_lock = threading.Lock()

def server_print(s, who=("main", )):
    with print_lock:
        print(f"[{datetime.now().strftime('%H:%M:%S')}] ({':'.join(map(str, who))}) {s}")