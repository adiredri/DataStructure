import random


class SkipListNode:
    def __init__(self, key: any, level: int):
        self.key = key
        self.forward = [None] * (level + 1)



class SkipList:
    def __init__(self, max_level: int, prob: float):
        self.max_level = max_level
        self.prob = prob
        self.header = SkipListNode(-1, self.max_level)
        self.level = 0

    def _get_random_level(self) -> int:
        level = 0
        while random.random() < self.prob and level < self.max_level:
            level += 1
        return level

    def add(self, key: int) -> None:
        update = [None] * (self.max_level + 1)
        current = self.header

        for i in reversed(range(self.level + 1)):
            while current.forward[i] is not None and current.forward[i].key < key:
                current = current.forward[i]
            update[i] = current

        current = current.forward[0]
        if current is None or current.key != key:
            new_level = self._get_random_level()
            if new_level > self.level:
                for i in range(self.level + 1, new_level + 1):
                    update[i] = self.header
                self.level = new_level

            new_node = SkipListNode(key, new_level)

            for i in range(new_level + 1):
                new_node.forward[i] = update[i].forward[i]
                update[i].forward[i] = new_node

    def search(self, key: int) -> bool:
        current = self.header
        for i in reversed(range(self.level + 1)):
            while current.forward[i] is not None and current.forward[i].key < key:
                current = current.forward[i]

        current = current.forward[0]
        return current is not None and current.key == key