from bloom_filter import BloomFilter


class MailFilter1:
    def __init__(self):
        self._bloom_filter = BloomFilter(n=100, prob=0.001)

    def add_spam(self, address: str) -> None:
        self._bloom_filter.add(address)

    def is_spam(self, address: str) -> bool:
        return self._bloom_filter.search(address)
