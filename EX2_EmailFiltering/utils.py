def random_hash(item: str, max_size: int, seed: int) -> int:

    hash_value = 0
    for char in item:
        hash_value = (hash_value * seed + ord(char)) & 0xFFFFFFFF
    return hash_value % max_size