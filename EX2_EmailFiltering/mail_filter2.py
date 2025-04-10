import math
import random

from bloom_filter import BloomFilter
from skip_list import SkipList
from utils import random_hash

HASH_SEED = 1
MAX_HASH = math.inf


class MailFilter2:
    CHECK_PROB = 1000

    def __init__(self):
        self._bloom_filter = BloomFilter(n=100, prob=0.001)
        self._skip_list = SkipList(max_level=6, prob=0.5)

    @staticmethod
    def _get_address_hash(address: str) -> int:
        return random_hash(item=address, max_size=MAX_HASH, seed=HASH_SEED)

    def add_spam(self, address: str) -> None:
        self._bloom_filter.add(item=address)
        self._skip_list.add(key=self._get_address_hash(address))

    def is_spam(self, address: str) -> bool:
        if (
            self._bloom_filter.search(item=address)
            or random.randint(1, MailFilter2.CHECK_PROB) == 1
        ):
            return self._skip_list.search(key=self._get_address_hash(address))
        return False
