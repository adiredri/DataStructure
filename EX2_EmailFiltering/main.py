"""
************  Assignment 2  ************

****  Student 1 : ****
Name: Adir Edri
ID: 206991762

****  Student 2 : ****
Name: Amit Edrei
ID: 211745385

"""

import random

from mail_filter1 import MailFilter1
from mail_filter2 import MailFilter2
from mail_filter3 import MailFilter3


def check_a():
    addresses = [f"user_{i + 1}@email.com" for i in range(500100)]
    random.shuffle(addresses)

    spam_addresses, normal_addresses = addresses[:100], addresses[100:]

    print("===  Check A  ===")
    mail_filter1 = MailFilter1()
    for address in spam_addresses:
        mail_filter1.add_spam(address)

    emails_to_test = 10
    test_spams = random.sample(spam_addresses, emails_to_test)
    for address in test_spams:
        if not mail_filter1.is_spam(address):
            raise Exception(f'Failed to set address "{address}" as spam')
    print(f"{emails_to_test} spam emails have been checked")

    fps = 0
    for address in normal_addresses:
        if mail_filter1.is_spam(address):
            fps += 1
    print(f"Number of FPs: {fps} ({round(fps / len(normal_addresses) * 100, 2)}%)")


def check_b():
    addresses = [f"user_{i + 1}@email.com" for i in range(500100)]
    random.shuffle(addresses)

    spam_addresses, normal_addresses = addresses[:100], addresses[100:]

    print("===  Check B  ===")
    mail_filter2 = MailFilter2()
    for address in spam_addresses:
        mail_filter2.add_spam(address)

    emails_to_test = 10
    test_spams = random.sample(spam_addresses, emails_to_test)
    for address in test_spams:
        if not mail_filter2.is_spam(address):
            raise Exception(f'Failed to set address "{address}" as spam')
    print(f"{emails_to_test} spam emails have been checked")

    fps = 0
    for address in normal_addresses:
        if mail_filter2.is_spam(address):
            fps += 1
    print(f"Number of FPs: {fps} ({round(fps / len(normal_addresses) * 100, 2)}%)")


def check_c():
    addresses = [f"user_{i + 1}@email.com" for i in range(500100)]
    random.shuffle(addresses)

    spam_addresses, normal_addresses = addresses[:100], addresses[100:]

    print("===  Check C  ===")
    mail_filter3 = MailFilter3()
    for address in spam_addresses:
        mail_filter3.add_spam(address)

    emails_to_test = 10
    test_spams = random.sample(spam_addresses, emails_to_test)
    for address in test_spams:
        if not mail_filter3.is_spam(address):
            raise Exception(f'Failed to set address "{address}" as spam')
    print(f"{emails_to_test} spam emails have been checked")

    first_100k_emails, rest_emails = (
        normal_addresses[:100000],
        normal_addresses[100000:],
    )

    fps = 0
    for address in first_100k_emails:
        if mail_filter3.is_spam(address):
            fps += 1
    print(
        f"First FPs: Number of FPs: {fps} ({round(fps / len(first_100k_emails) * 100, 2)}%)"
    )

    to_remove = random.sample(spam_addresses, 50)
    new_spams = random.sample(first_100k_emails, 50)

    for address in to_remove:
        mail_filter3.remove_spam(address)
    for address in new_spams:
        mail_filter3.add_spam(address)

    fps = 0
    for address in rest_emails:
        if mail_filter3.is_spam(address):
            fps += 1
    print(
        f"Second FPs: Number of FPs: {fps} ({round(fps / len(rest_emails) * 100, 2)}%)"
    )


def main():
    check_a()
    check_b()
    check_c()


if __name__ == "__main__":
    main()
