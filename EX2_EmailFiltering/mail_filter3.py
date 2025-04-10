from counting_bloom_filter import CountingBloomFilter


class MailFilter3:
    def __init__(self):
        self._bloom_filter = CountingBloomFilter(n=100, prob=0.001)

    def add_spam(self, address: str) -> None:
        self._bloom_filter.add(address)

    def remove_spam(self, address: str) -> None:
        self._bloom_filter.remove(item=address)

    def is_spam(self, address: str) -> bool:
        return self._bloom_filter.search(address)
