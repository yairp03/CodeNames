from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
from sqlalchemy import Column, Integer, String
from hashlib import md5
import random

_engine = create_engine(f"sqlite:///code_names.db?check_same_thread=False")

_Base = declarative_base()


class _User(_Base):
    __tablename__ = "user"
    id = Column(Integer, primary_key=True)
    username = Column(String)
    password = Column(String)


class _Word(_Base):
    __tablename__ = "word"
    id = Column(Integer, primary_key=True)
    word = Column(String)


_Base.metadata.create_all(_engine)
_Session = sessionmaker(bind=_engine)


class Database:
    _db = _Session()
    _words = set(_db.query(_Word).all())

    @classmethod
    def user_exists(cls, username: str, password: str = None) -> bool:
        if not password:
            return (
                len(cls._db.query(_User).filter(_User.username == username).all()) == 1
            )
        else:
            return (
                len(
                    cls._db.query(_User)
                    .filter(
                        _User.username == username
                        and _User.password == md5(password.encode()).hexdigest()
                    )
                    .all()
                )
                == 1
            )

    @classmethod
    def create_user(cls, username, password):

        if cls.user_exists(username):
            return False
        user = _User(username=username, password=md5(password.encode()).hexdigest())
        cls._db.add(user)
        cls._db.commit()
        return True

    @classmethod
    def delete_user(cls, username):
        if not cls.user_exists(username):
            return False
        cls._db.query(_User).filter(_User.username == username).delete()
        cls._db.commit()
        return True

    @classmethod
    def get_words(cls, amount=-1):
        words = cls._db.query(_Word).all()
        if 1 <= amount <= len(words):
            words = random.sample(words, amount)
        return [w.word for w in words]

    @classmethod
    def add_words(cls, *words):
        for w in words:
            cls._db.add(_Word(word=w))
        cls._db.commit()
