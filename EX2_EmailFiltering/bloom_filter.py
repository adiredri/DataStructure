import math

from utils import random_hash


class BloomFilter:
    def __init__(self, n: int, prob: float):
        self.m = -math.ceil(n * math.log(prob) / (math.log(2) ** 2))
        self.k = math.ceil((self.m / n) * math.log(2))

        self._bit_array = [0] * self.m

    def _get_indexes(self, item: str) -> list[int]:
        indexes = []
        for i in range(self.k):
            indexes.append(random_hash(item=item, max_size=self.m, seed=i))
        return indexes

    def add(self, item: str) -> None:
        for index in self._get_indexes(item=item):
            self._bit_array[index] = 1

    def search(self, item: str) -> bool:
        for index in self._get_indexes(item=item):
            if self._bit_array[index] == 0:
                return False
        return True
