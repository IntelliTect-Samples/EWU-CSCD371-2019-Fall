﻿using System;
using System.Collections.Generic;

namespace Mailbox {
    public class Mailboxes {

        public Mailbox[,] _Mailboxes { get; }

        public Mailboxes(List<Mailbox> mailboxes, int width, int height) {
            if (width < 0) {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height < 0) {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            _Mailboxes = new Mailbox[width, height];
        }

        internal (int, int) findValidLocation(Person owner) {
            for (int i = 0; i < _Mailboxes.Length; i++) {
                for (int j = 0; j < _Mailboxes.GetLength(i); j++) {
                    if (canOwnBox(owner, i, j)) {
                        return (i, j);
                    }
                }
            }
            return (-1, -1); // No available box
        }

        private bool canOwnBox(Person owner, int x, int y) {
            //Checking current location
            if (_Mailboxes[x, y] != null) {
                return false;
            }
            //Checking right
            if (x + 1 <= _Mailboxes.Length && _Mailboxes[x + 1, y] != null && _Mailboxes[x + 1, y]._Owner.Equals(owner)) {
                return false;
            }
            //Checking left
            if (x - 1 >= 0 && _Mailboxes[x - 1, y] != null && _Mailboxes[x - 1, y]._Owner.Equals(owner)) {
                return false;
            }
            //Checking up
            if (y - 1 >= 0 && _Mailboxes[x, y - 1] != null && !_Mailboxes[x, y - 1]._Owner.Equals(owner)) {
                return false;
            }
            //Checking down
            if (y + 1 <= _Mailboxes.GetLength(0) && _Mailboxes[x, y + 1] != null && !_Mailboxes[x, y + 1]._Owner.Equals(owner)) {
                return false;
            }
            return true;
        }
    }
}
